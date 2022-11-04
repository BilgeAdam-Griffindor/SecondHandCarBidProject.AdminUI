using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidResultController : Controller
    {
        private IValidator<BidResultAddSendDTO> _validatorAdd;
        private IValidator<BidResultUpdateSendDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public BidResultController(IValidator<BidResultAddSendDTO> validatorAdd, IValidator<BidResultUpdateSendDTO> validatorUpdate, IBaseDAL baseDAL, ILogCatcher logCatcher)
        {
            _logCatcher = logCatcher;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
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
                ResponseModel<BidResultListPageDTO> response = await _baseDAL.GetByFilterAsync<BidResultListPageDTO>("BidResult/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    BidResultListViewModel viewData = new BidResultListViewModel(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. BidResult/Index Kod: " );
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
                ResponseModel<BidResultAddPageDTO> response = await _baseDAL.GetByFilterAsync<BidResultAddPageDTO>("BidResult/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    BidResultAddViewModel viewData = new BidResultAddViewModel(
                        Guid.Empty,
                        "",
                        response.Data.BidOfferList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList());


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. BidResult/Add [GET] Kod: " );
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
        public async Task<IActionResult> Add(BidResultAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            BidResultAddSendDTO addDTO = new BidResultAddSendDTO(viewData.BidOfferId, viewData.Explanation, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<BidResultAddSendDTO, bool>(addDTO, "BidResult/Add", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. BidResult/Add [POST] Kod: " );
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
        public async Task<IActionResult> Update(Guid id)
        {
            string queryString = "bidResultId=" + id;

            //BaseApi
            try
            {
                ResponseModel<BidResultUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<BidResultUpdatePageDTO>("BidResult/Update", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    BidResultUpdateViewModel viewData = new BidResultUpdateViewModel(response.Data.Id, response.Data.Explanation);

                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. BidResult/Update [GET] Kod: ");
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
        public async Task<IActionResult> Update(BidResultUpdateViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            BidResultUpdateSendDTO updateDTO = new BidResultUpdateSendDTO(viewData.Id, viewData.Explanation, new Guid(HttpContext.Session.GetString("currentUserId")));

            //Validate
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDTO);
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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<BidResultUpdateSendDTO, bool>(updateDTO, "BidResult/Update", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {

                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. BidResult/Update [POST] Kod: " );
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            string queryString = "bidResultId=" + id + "&modifiedBy=" + HttpContext.Session.GetString("currentUserId");

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "BidResult/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. BidResult/Delete Kod: " );
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
