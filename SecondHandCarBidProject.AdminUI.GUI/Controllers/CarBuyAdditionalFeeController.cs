using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyAdditionalFeeController : Controller
    {
        private IValidator<CarBuyAdditionalFeeAddSendDTO> _validatorAdd;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public CarBuyAdditionalFeeController(IValidator<CarBuyAdditionalFeeAddSendDTO> validatorAdd, IBaseDAL baseDAL, ILogCatcher logCatcher)
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
                ResponseModel<CarBuyAdditionalFeeListPageDTO> response = await _baseDAL.GetByFilterAsync<CarBuyAdditionalFeeListPageDTO>("CarBuyAdditionalFee/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarBuyAdditionalFeeListViewModel viewData = new CarBuyAdditionalFeeListViewModel(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuyAdditionalFee/Index Kod: ");
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
                ResponseModel<CarBuyAdditionalFeeAddPageDTO> response = await _baseDAL.GetByFilterAsync<CarBuyAdditionalFeeAddPageDTO>("CarBuyAdditionalFee/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CarBuyAdditionalFeeAddViewModel viewData = new CarBuyAdditionalFeeAddViewModel(
                        Guid.Empty,
                        Guid.Empty,
                        Guid.Empty,
                        response.Data.CarBuyList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.NotaryFeeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.CommissionFeeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList());


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuyAdditionalFee/Add [GET] Kod: ");
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
        public async Task<IActionResult> Add(CarBuyAdditionalFeeAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarBuyAdditionalFeeAddSendDTO addDTO = new CarBuyAdditionalFeeAddSendDTO(viewData.CarBuyId, viewData.NotaryFeeId, viewData.CommissionFeeId, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CarBuyAdditionalFeeAddSendDTO, bool>(addDTO, "CarBuyAdditionalFee/Add", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CarBuyAdditionalFee/Add [POST] Kod: " );
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
            string queryString = "carBuyAdditionalFeeId=" + id + "&modifiedBy="+ HttpContext.Session.GetString("currentUserId");
            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CarBuyAdditionalFee/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuyAdditionalFee/Delete Kod: ");
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
