using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.Commons;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyController : Controller
    {
        private IValidator<CarBuyAddSendDTO> _validatorAdd;
        private IValidator<CarBuyUpdateSendDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public CarBuyController(IValidator<CarBuyAddSendDTO> validatorAdd, IValidator<CarBuyUpdateSendDTO> validatorUpdate, IBaseDAL baseDAL, ILogCatcher logCatcher)
        {
            _logCatcher = logCatcher;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(string brandId = "", string modelId = "", string statusId = "", int page = 1, int itemPerPage = 100)
        {
            ViewData["page"] = page;
            ViewData["itemPerPage"] = itemPerPage;
            ViewData["brandId"] = brandId;
            ViewData["modelId"] = modelId;
            ViewData["statusId"] = statusId;

            string queryString = "page=" + page + "&itemPerPage=" + itemPerPage;
            if (!string.IsNullOrEmpty(brandId))
                queryString += "&brandId=" + brandId;
            if (!string.IsNullOrEmpty(modelId))
                queryString += "&modelId=" + modelId;
            if (!string.IsNullOrEmpty(statusId))
                queryString += "&statusId=" + statusId;

            //BaseApi
            try
            {
                ResponseModel<CarBuyListPageDTO> response = await _baseDAL.GetByFilterAsync<CarBuyListPageDTO>("CarBuy/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarBuyListViewModel viewData = new CarBuyListViewModel(
                        response.Data.BrandList.Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == brandId
                        }).ToList(),
                        response.Data.ModelList.Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == modelId
                        }).ToList(),
                        response.Data.StatusList.Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == statusId
                        }).ToList(),
                        response.Data.TableRows,
                        response.Data.maxPages);

                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuy/Index Kod: " + response.statusCode);
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
                ResponseModel<CarDetailAddPageDTO> response = await _baseDAL.GetByFilterAsync<CarDetailAddPageDTO>("CarBuy/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CarBuyAddViewModel viewData = new CarBuyAddViewModel(
                        0, 0, "", 0, 0, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, new List<Guid>(), new List<IFormFile>(),
                        response.Data.BrandList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.ModelList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.BodyTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.FuelTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.GearTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.VersionList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.ColorList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.OptionalHardwareList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList());


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuy/Add [GET] Kod: " + response.statusCode);
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
        public async Task<IActionResult> Add(CarBuyAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarBuyAddSendDTO addDTO = new CarBuyAddSendDTO(
                viewData.Kilometre, viewData.CarYear, viewData.CarDescription,
                viewData.CarBrandId, viewData.CarModelId, viewData.BodyTypeId, viewData.FuelTypeId,
                viewData.GearTypeId, viewData.VersionId, viewData.ColorId, viewData.OptionalHardwareIds, viewData.CarImages.ToListByteArray(),
                new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CarBuyAddSendDTO, bool>(addDTO, "CarBuy/Add", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CarBuy/Add [POST] Kod: " + response.statusCode);
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
            string queryString = "carBuyId=" + id;

            //BaseApi
            try
            {
                ResponseModel<CarBuyUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<CarBuyUpdatePageDTO>("CarBuy/Update", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarBuyUpdateViewModel viewData = new CarBuyUpdateViewModel(
                        response.Data.Id,
                        response.Data.CarId,
                        response.Data.UserFullName,
                        response.Data.PreValuationPrice,
                        response.Data.BidPrice,
                        response.Data.Kilometre,
                        response.Data.CarYear,
                        response.Data.CarDescription,
                        response.Data.CarBrandId,
                        response.Data.CarModelId,
                        response.Data.StatusId,
                        response.Data.BodyTypeId,
                        response.Data.FuelTypeId,
                        response.Data.GearTypeId,
                        response.Data.VersionId,
                        response.Data.ColorId,
                        response.Data.OptionalHardwareIds,
                        new List<IFormFile>(), //TODO placeholder for response.Data.CarImages
                                               //response.Data.CarImages, //TODO How to display images
                        response.Data.BrandList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.ModelList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.StatusList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.BodyTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.FuelTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.GearTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.VersionList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.ColorList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList(),
                        response.Data.OptionalHardwareList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                            Selected = x.Id.ToString() == response.Data.Id.ToString()
                        }).ToList());

                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuy/Update [GET] Kod: " + response.statusCode);
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
        public async Task<IActionResult> Update(CarBuyUpdateViewModel viewData)
        {

            //Convert to send dto (Possibly inefficient to convert before validation)
            CarBuyUpdateSendDTO updateDTO = new CarBuyUpdateSendDTO(
                viewData.Id, viewData.StatusId, viewData.PreValuationPrice, viewData.BidPrice,
                new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CarBuyUpdateSendDTO, bool>(updateDTO, "CarBuy/Update", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CarBuy/Update [POST] Kod: " + response.statusCode);
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
            string queryString = "carBuyId=" + id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CarBuy/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBuy/Delete Kod: " + response.statusCode);
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
