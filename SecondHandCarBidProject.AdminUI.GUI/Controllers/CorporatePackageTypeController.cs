using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SecondHandCarBidProject.AdminUI.Validator.CorporatePackageType;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporatePackageTypeController : Controller
    {
        private IValidator<CorporatePackageTypeAddDTO> _validatorAdd;
        private IValidator<CorporatePackageTypeUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public CorporatePackageTypeController(IValidator<CorporatePackageTypeAddDTO> validatorAdd,
            IValidator<CorporatePackageTypeUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<CorporatePackageTypeListPageDTO>(null, null);
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
                ResponseModel<CorporatePackageTypeListPageDTO> response = await _baseDAL.GetByFilterAsync<CorporatePackageTypeListPageDTO>("CorporatePackageType/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporatePackageTypeListViewModels viewData = new CorporatePackageTypeListViewModels(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCorporatePackageType()
        {
            try
            {
                ResponseModel<CorporatePackageTypeAddPageDTO> response = await _baseDAL.GetByFilterAsync<CorporatePackageTypeAddPageDTO>("CorporatePackageType/AddCorporatePackageType", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CorporatePackageTypeAddViewModels viewData = new CorporatePackageTypeAddViewModels(
                        "",
                        0,
                        1,
                          response.Data.CreatedByList.Select(x => new SelectListItem
                          {
                              Value = x.Id.ToString(),
                              Text = x.Name
                          }).ToList());


                    return View(viewData);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCorporatePackageType(CorporatePackageTypeAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CorporatePackageTypeAddDTO addDTO = new CorporatePackageTypeAddDTO(viewData.PackageName,  new Guid(HttpContext.Session.GetString("currentUserId")), viewData.CountOfBids);

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CorporatePackageTypeAddDTO, bool>(addDTO, "CorporatePackageType/AddCorporatePackageType", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {

                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }

                //TODO Logging (May not necessary if there is middleware)
                try
                {

                }
                catch (Exception ex)
                {
                    //return RedirectToAction("Index", "Error");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateCorporatePackageType(Int16 Id)
        {
            string queryString = "CorporatePackageTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<CorporatePackageTypeUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<CorporatePackageTypeUpdatePageDTO>("CorporatePackageType/UpdateCorporatePackageType", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporatePackageTypeUpdateViewModels viewData = new CorporatePackageTypeUpdateViewModels(
                        response.Data.Id,
                        response.Data.PackageName,
                        response.Data.CountOfBids,
                        response.Data.IsActive,
                         response.Data.CreatedByList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList());

                    return View(viewData);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UpdateCorporatePackageType(CorporatePackageTypeUpdateViewModels viewData)
        {
            CorporatePackageTypeUpdateDTO updateDTO = new CorporatePackageTypeUpdateDTO(viewData.Id, viewData.PackageName, viewData.CountOfBids, viewData.IsActive, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CorporatePackageTypeUpdateDTO, bool>(updateDTO, "CorporatePackageType/UpdateCorporatePackageType", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {

                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }

                //TODO Logging (May not necessary if there is middleware)
                try
                {

                }
                catch (Exception ex)
                {
                    //return RedirectToAction("Index", "Error");
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RemoveCorporatePackageType(Int16 Id)
        {
            string queryString = "CorporatePackageTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CorporatePackageType/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
