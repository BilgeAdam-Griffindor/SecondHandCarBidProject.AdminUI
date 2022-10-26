using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SecondHandCarBidProject.AdminUI.Validator.CarBrand;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBrandController : Controller
    {
        private IValidator<CarBrandAddDTO> _validatorAdd;
        private IValidator<CarBrandUpdateSendDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public CarBrandController(IValidator<CarBrandAddDTO> validatorAdd, IValidator<CarBrandUpdateSendDTO> validatorUpdate, IBaseDAL baseDAL, ILogCatcher logCatcher)
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
                ResponseModel<CarBrandListPageDTO> response = await _baseDAL.GetByFilterAsync<CarBrandListPageDTO>("CarBrand/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarBrandListViewModel viewData = new CarBrandListViewModel(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBrand/Index Kod: " + response.statusCode);
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
        public IActionResult Add()
        {
            return View(new CarBrandAddViewModel(""));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CarBrandAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarBrandAddDTO addDTO = new CarBrandAddDTO(viewData.BrandName, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CarBrandAddDTO, bool>(addDTO, "CarBrand/Add", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CarBrand/Add [POST] Kod: " + response.statusCode);
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
        public async Task<IActionResult> Update(short id)
        {
            string queryString = "brandId=" + id;

            //BaseApi
            try
            {
                ResponseModel<CarBrandUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<CarBrandUpdatePageDTO>("CarBrand/Update", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CarBrandUpdateViewModel viewData = new CarBrandUpdateViewModel(response.Data.Id, response.Data.BrandName);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBrand/Update [GET] Kod: " + response.statusCode);
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
        public async Task<IActionResult> Update(CarBrandUpdateViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CarBrandUpdateSendDTO updateDTO = new CarBrandUpdateSendDTO(viewData.Id, viewData.BrandName, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CarBrandUpdateSendDTO, bool>(updateDTO, "CarBrand/Update", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {

                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CarBrand/Update [POST] Kod: " + response.statusCode);
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
        public async Task<IActionResult> Delete(int id)
        {
            string queryString = "brandId=" + id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CarBrand/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. CarBrand/Delete Kod: " + response.statusCode);
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
