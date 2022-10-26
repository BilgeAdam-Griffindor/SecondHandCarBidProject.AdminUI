using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class FavoriteUserSearchesController : Controller
    {
        private IValidator<FavoriteUserSearchesAddDTO> _validatorAdd;
        private IValidator<FavoriteUserSearchesUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;


        public FavoriteUserSearchesController(IValidator<FavoriteUserSearchesAddDTO> validatorAdd,
            IValidator<FavoriteUserSearchesUpdateDTO> validatorUpdate, IBaseDAL baseDAL, ILogCatcher logCatcher)
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
            //var data = await _baseDAL.ListAll<FavoriteUserSearchesListPageDTO>(null, null);
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
                ResponseModel<FavoriteUserSearchesListPageDTO> response = await _baseDAL.GetByFilterAsync<FavoriteUserSearchesListPageDTO>("FavoriteUserSearches/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    FavoriteUserSearchesListViewModels viewData = new FavoriteUserSearchesListViewModels(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. FavoriteUserSearches/Index Kod: " + response.statusCode);
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
        public async Task<IActionResult> AddFavoriteUserSearches()
        {
            try
            {
                ResponseModel<FavoriteUserSearchesAddPageDTO> response = await _baseDAL.GetByFilterAsync<FavoriteUserSearchesAddPageDTO>("FavoriteUserSearches/AddFavoriteUserSearches", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    FavoriteUserSearchesAddViewModels viewData = new FavoriteUserSearchesAddViewModels(
                        "",
                        Guid.Empty,
                        true,
                        DateTime.Now,
                        response.Data.BaseUserList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList());


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. FavoriteUserSearches/AddFavoriteUserSearches [GET] Kod: " + response.statusCode);
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
        public async Task<IActionResult> AddFavoriteUserSearches(FavoriteUserSearchesAddViewModels viewData)
        {

            //Convert to send dto (Possibly inefficient to convert before validation)
            FavoriteUserSearchesAddDTO addDTO = new FavoriteUserSearchesAddDTO(viewData.SearchText, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.CreatedDate);

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<FavoriteUserSearchesAddDTO, bool>(addDTO, "FavoriteUserSearches/AddFavoriteUserSearches", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. FavoriteUserSearches/AddFavoriteUserSearches [POST] Kod: " + response.statusCode);
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
        public async Task<IActionResult> UpdateFavoriteUserSearches(Guid Id)
        {
            string queryString = "CorporationTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<FavoriteUserSearchesUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<FavoriteUserSearchesUpdatePageDTO>("FavoriteUserSearches/UpdateFavoriteUserSearches", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    FavoriteUserSearchesUpdateViewModels viewData = new FavoriteUserSearchesUpdateViewModels(
                        response.Data.Id,
                        response.Data.SearchText,
                        response.Data.BaseUserId,
                        response.Data.IsActive,
                        response.Data.CreatedDate,
                         response.Data.BaseUserList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList());

                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. FavoriteUserSearches/FavoriteUserSearchesCorporatePackageType [GET] Kod: " + response.statusCode);
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
        public async Task<IActionResult> UpdateFavoriteUserSearches(FavoriteUserSearchesUpdateViewModels viewData)
        {
            FavoriteUserSearchesUpdateDTO updateDTO = new FavoriteUserSearchesUpdateDTO(viewData.Id, viewData.SearchText, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.IsActive, viewData.CreatedDate);

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<FavoriteUserSearchesUpdateDTO, bool>(updateDTO, "FavoriteUserSearches/UpdateFavoriteUserSearches", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. FavoriteUserSearches/UpdateFavoriteUserSearches [POST] Kod: " + response.statusCode);
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
        public async Task<IActionResult> RemoveFavoriteUserSearches(Guid Id)
        {
            string queryString = "FavoriteUserSearchesID=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "FavoriteUserSearches/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. FavoriteUserSearches/Delete Kod: " + response.statusCode);
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
