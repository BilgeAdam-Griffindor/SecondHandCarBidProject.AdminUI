using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.Commons;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;
using LogLevel = SercondHandCarBidProject.Logging.Concrete.LogLevel;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarController : Controller
    {
        IValidator<CarDetailAddSendDTO> _validatorAdd;
        IValidator<CarDetailUpdateSendDTO> _validatorUpdate;
        IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public CarController(IValidator<CarDetailAddSendDTO> validatorAdd, IValidator<CarDetailUpdateSendDTO> validatorUpdate, IBaseDAL baseDAL, ILogCatcher logCatcher)
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
                ResponseModel<CarListPageDTO> response = await _baseDAL.GetByFilterAsync<CarListPageDTO>("Car/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarListViewModel viewData = new CarListViewModel(
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
                    throw new Exception("Başarısız işlem. Car/Index Kod: ");
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
        public async Task<IActionResult> CarDetailInformation() //CarAdd
        {
            //BaseApi
            try
            {
                ResponseModel<CarDetailAddPageDTO> response = await _baseDAL.GetByFilterAsync<CarDetailAddPageDTO>("Car/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CarDetailAddViewModel viewData = new CarDetailAddViewModel(
                        0, 0, 0, false, "", 0, 0, 0, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, new List<Guid>(), new List<IFormFile>(),
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
                        response.Data.StatusList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.CorporationList.Select(x => new SelectListItem
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
                        }).ToList(), null);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. Car/CarDetailInformation [GET] Kod: ");
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
        public async Task<IActionResult> CarDetailInformation(CarDetailAddViewModel viewData) //CarAdd
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarDetailAddSendDTO addDTO = new CarDetailAddSendDTO(
                viewData.Price, viewData.Kilometre, viewData.CarYear, viewData.IsCorporate, viewData.CarDescription,
                viewData.CarBrandId, viewData.CarModelId, viewData.StatusId, viewData.BodyTypeId, viewData.FuelTypeId,
                viewData.GearTypeId, viewData.VersionId, viewData.ColorId, viewData.OptionalHardwareIds, viewData.CarImages.ToListByteArray(),
                new Guid(HttpContext.Session.GetString("currentUserId")), viewData.CorporationId);

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CarDetailAddSendDTO, bool>(addDTO, "Car/Add", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. Car/CarDetailInformation [POST] Kod: ");
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
            string queryString = "carId=" + id;

            //BaseApi
            try
            {
                ResponseModel<CarDetailUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<CarDetailUpdatePageDTO>("Car/Update", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarDetailUpdateViewModel viewData = new CarDetailUpdateViewModel(
                        response.Data.Id,
                        response.Data.Price,
                        response.Data.Kilometre,
                        response.Data.CarYear,
                        response.Data.IsCorporate,
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
                        response.Data.CorporationList.Select(x => new SelectListItem
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
                        }).ToList(),
                        response.Data.CorporationId);

                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. Car/Update [POST] Kod: ");
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
        public async Task<IActionResult> Update(CarDetailUpdateViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarDetailUpdateSendDTO updateDTO = new CarDetailUpdateSendDTO(
                viewData.Id, viewData.Price, viewData.Kilometre, viewData.CarYear, viewData.IsCorporate, viewData.CarDescription,
                viewData.CarBrandId, viewData.CarModelId, viewData.StatusId, viewData.BodyTypeId, viewData.FuelTypeId,
                viewData.GearTypeId, viewData.VersionId, viewData.ColorId, viewData.OptionalHardwareIds,
                viewData.CarImages.ToListByteArray(), //TODO placeholder will probably need to be changed
                viewData.CorporationId,
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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CarDetailUpdateSendDTO, bool>(updateDTO, "Car/Update", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. Car/Update [POST] Kod: ");
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
            string queryString = "carId=" + id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "Car/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. Car/Delete Kod: " );
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

        public async Task<IActionResult> CarSave()//CarDTO carDTO
        {

            return View();
        }
    }
}
