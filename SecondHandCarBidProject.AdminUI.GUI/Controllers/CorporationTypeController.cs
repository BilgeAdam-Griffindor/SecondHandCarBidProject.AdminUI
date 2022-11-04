using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SecondHandCarBidProject.AdminUI.Validator.CorporatePackageType;
using SecondHandCarBidProject.AdminUI.Validator.CorporationType;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporationTypeController : Controller
    {
        private IValidator<CorporationTypeAddDTO> _validatorAdd;
        private IValidator<CorporationTypeUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;


        public CorporationTypeController(IValidator<CorporationTypeAddDTO> validatorAdd,
            IValidator<CorporationTypeUpdateDTO> validatorUpdate, IBaseDAL baseDAL, ILogCatcher logCatcher)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
            _logCatcher = logCatcher;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<CorporationTypeListPageDTO>(null, null);
            //if (data.IsSuccess)
            //{
            //    return View(data.Data);
            //}
            ViewData["page"] = page;
            ViewData["itemPerPage"] = itemPerPage;

            string queryString = "page=" + page + "&itemPerPage=" + itemPerPage;

            //BaseApi
            try
            {
                ResponseModel<CorporationTypeListPageDTO> response = await _baseDAL.GetByFilterAsync<CorporationTypeListPageDTO>("CorporationType/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporationTypeListViewModels viewData = new CorporationTypeListViewModels(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CorporationType/Index Kod: " + response.statusCode);
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
                }

                return RedirectToAction("Index", "Error");
            }
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCorporationType()
        {
            try
            {
                ResponseModel<CorporationTypeAddPageDTO> response = await _baseDAL.GetByFilterAsync<CorporationTypeAddPageDTO>("CorporationType/AddCorporation", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CorporationTypeAddViewModels viewData = new CorporationTypeAddViewModels(
                        "",
                        true);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CorporationType/AddCorporationType [GET] Kod: " + response.statusCode);
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
                }

                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCorporationType(CorporationTypeAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CorporationTypeAddDTO addDTO = new CorporationTypeAddDTO(viewData.CorporationTypeName,  new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CorporationTypeAddDTO, bool>(addDTO, "CorporationType/AddCorporationType", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CorporationType/AddCorporationType [POST] Kod: " + response.statusCode);
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
                    }

                    return RedirectToAction("Index", "Error");
                }
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateCorporationType(int Id)
        {
            string queryString = "CorporationTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<CorporationTypeUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<CorporationTypeUpdatePageDTO>("Corporation/UpdateCorporation", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporationTypeUpdateViewModels viewData = new CorporationTypeUpdateViewModels(
                        response.Data.Id,
                        response.Data.CorporationTypeName,
                        response.Data.IsActive);

                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. CorporationType/UpdateCorporationType [GET] Kod: " + response.statusCode);
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
                }

                return RedirectToAction("Index", "Error");
            }
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCorporationType(CorporationTypeUpdateViewModels viewData)
        {
            CorporationTypeUpdateDTO updateDTO = new CorporationTypeUpdateDTO(viewData.Id, viewData.CorporationTypeName, viewData.IsActive, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CorporationTypeUpdateDTO, bool>(updateDTO, "CorporationType/UpdateCorporationType", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. CorporationType/UpdateCorporationType [POST] Kod: " + response.statusCode);
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
                    }

                    return RedirectToAction("Index", "Error");
                }
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveCorporationType(int Id)
        {
            string queryString = "CorporationTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CorporationType/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. CorporationType/Delete Kod: " + response.statusCode);
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
                }

                return RedirectToAction("Index", "Error");
            }
        }
    }
}
