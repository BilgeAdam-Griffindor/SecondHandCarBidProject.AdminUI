using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DAL.Concrete;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyStatusHistoryController : Controller
    {
        private IValidator<CarBuyStatusHistoryAddSendDTO> _validatorAdd;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public CarBuyStatusHistoryController(IValidator<CarBuyStatusHistoryAddSendDTO> validatorAdd, IBaseDAL baseDAL, ILogCatcher logCatcher)
        {
            _logCatcher = logCatcher;
            _validatorAdd = validatorAdd;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            ViewData["page"] = page;
            ViewData["itemPerPage"] = itemPerPage;

            string queryString = "page=" + page + "&itemPerPage=" + itemPerPage;

            //BaseApi
            try
            {
                ResponseModel<CarBuyStatusHistoryListPageDTO> response = await _baseDAL.GetByFilterAsync<CarBuyStatusHistoryListPageDTO>("CarBuyStatusHistory/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarBuyStatusHistoryListViewModel viewData = new CarBuyStatusHistoryListViewModel(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuyStatusHistory/Index Kod: " + response.statusCode);
                }

            }
            catch (Exception ex)
            {
                try
                {
                    await _logCatcher.WriteLogWarning(ex);
                }
                catch
                {
                    //Just so that the program won't break if there is a problem with logging
                }

                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {

            //BaseApi
            try
            {
                ResponseModel<CarBuyStatusHistoryAddPageDTO> response = await _baseDAL.GetByFilterAsync<CarBuyStatusHistoryAddPageDTO>("CarBuyStatusHistory/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CarBuyStatusHistoryAddViewModel viewData = new CarBuyStatusHistoryAddViewModel(
                        Guid.Empty,
                        0,
                        "",
                        response.Data.CarBuyList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.StatusValueList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList());


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuyStatusHistory/Add [GET] Kod: " + response.statusCode);
                }

            }
            catch (Exception ex)
            {
                try
                {
                    await _logCatcher.WriteLogWarning(ex);
                }
                catch
                {
                    //Just so that the program won't break if there is a problem with logging
                }

                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CarBuyStatusHistoryAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarBuyStatusHistoryAddSendDTO addDTO = new CarBuyStatusHistoryAddSendDTO(viewData.CarBuyId, viewData.StatusValueId, viewData.Explanation, new Guid(HttpContext.Session.GetString("currentUserId")));

            //Validate
            ValidationResult result = await _validatorAdd.ValidateAsync(addDTO);
            if (!result.IsValid)
            {
                //If not valid print errors
                List<ValidationFailure> errors = result.Errors;
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(viewData);
            }
            else
            {
                //BaseApi
                try
                {
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CarBuyStatusHistoryAddSendDTO, bool>(addDTO, "CarBuyStatusHistory/Add", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CarBuyStatusHistory/Add [POST] Kod: " + response.statusCode);
                    }

                }
                catch (Exception ex)
                {
                    try
                    {
                        await _logCatcher.WriteLogWarning(ex);
                    }
                    catch
                    {
                        //Just so that the program won't break if there is a problem with logging
                    }

                    return RedirectToAction("Index", "Error");
                }
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            string queryString = "carbuyStatusHistoryId=" + id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CarBuyStatusHistory/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuyStatusHistory/Delete Kod: " + response.statusCode);
                }

            }
            catch (Exception ex)
            {
                try
                {
                    await _logCatcher.WriteLogWarning(ex);
                }
                catch
                {
                    //Just so that the program won't break if there is a problem with logging
                }

                return RedirectToAction("Index", "Error");
            }
        }
    }
}
