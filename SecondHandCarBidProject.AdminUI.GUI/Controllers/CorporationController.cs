using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Concrete;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SecondHandCarBidProject.AdminUI.Validator.CorporatePackageType;
using SecondHandCarBidProject.AdminUI.Validator.Corporation;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporationController : Controller
    {
        private IValidator<CorporationAddDTO> _validatorAdd;
        private IValidator<CorporationUpdateDTO> _validatorUpdate;

        private IBaseDAL _baseDAL;

        public CorporationController(IValidator<CorporationAddDTO> validatorAdd,
            IValidator<CorporationUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<CorporationListPageDTO>(null, null);
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
                ResponseModel<CorporationListPageDTO> response = await _baseDAL.GetByFilterAsync<CorporationListPageDTO>("Corporation/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporationListViewModels viewData = new CorporationListViewModels(response.Data.TableRows, response.Data.maxPages);


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
        [HttpGet]
        public async Task<IActionResult> AddCorporation()
        {
            try
            {
                ResponseModel<CorporationAddPageDTO> response = await _baseDAL.GetByFilterAsync<CorporationAddPageDTO>("Corporation/AddCorporation", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CorporationAddViewModels viewData = new CorporationAddViewModels(
                        "",
                        0,
                        "",
                        0,
                        0,
                        true,
                        DateTime.Now,
                        DateTime.Now,
                        Guid.Empty,
                        Guid.Empty,
                         response.Data.AddressInfoList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList(),
                        response.Data.CorporationTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                         response.Data.CorporatePackageTypeList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList(),
                        response.Data.CreatedByList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.ModifiedByList.Select(x => new SelectListItem
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
        public async Task<IActionResult> AddCCorporation(CorporationAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CorporationAddDTO addDTO = new CorporationAddDTO(viewData.CompanyName, viewData.AddressInfoId, viewData.PhoneNumber, viewData.CorporationTypeId, viewData.CorporatePackageTypeId, viewData.CreatedDate, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CorporationAddDTO, bool>(addDTO, "Corporation/AddCorporation", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> UpdateCorporation(int Id)
        {
            string queryString = "CorporatePackageTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<CorporationUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<CorporationUpdatePageDTO>("Corporation/UpdateCorporation", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporationUpdateViewModels viewData = new CorporationUpdateViewModels(
                        response.Data.Id,
                        response.Data.CompanyName,
                        response.Data.AddressInfoId,
                        response.Data.PhoneNumber,
                        response.Data.CorporationTypeId,
                        response.Data.CorporatePackageTypeId,
                        response.Data.IsActive,
                        response.Data.CreatedDate,
                        response.Data.ModifiedDate,
                        response.Data.CreatedBy,
                        response.Data.ModifiedBy,
                         response.Data.AddressInfoList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList(),
                        response.Data.CorporationTypeList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                         response.Data.CorporationPackageTypeList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList(),
                        response.Data.CreatedByList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.ModifiedByList.Select(x => new SelectListItem
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
        public async Task<IActionResult> UpdateCorporation(CorporationUpdateViewModels viewData)
        {
            CorporationUpdateDTO updateDTO = new CorporationUpdateDTO(viewData.Id, viewData.CompanyName, viewData.AddressInfoId, viewData.PhoneNumber, viewData.CorporationTypeId, viewData.CorporatePackageTypeId, viewData.IsActive, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CorporationUpdateDTO, bool>(updateDTO, "Corporation/UpdateCorporation", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> RemoveCorporation(int Id)
        {
            string queryString = "CorporationId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "Corporation/Delete", HttpContext.Session.GetString("userToken"));

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
