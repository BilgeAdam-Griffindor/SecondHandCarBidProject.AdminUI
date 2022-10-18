﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporationUserController : Controller
    {
        private IValidator<CorporationUserAddDTO> _validatorAdd;
        private IValidator<CorporationUserUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public CorporationUserController(IValidator<CorporationUserAddDTO> validatorAdd,
            IValidator<CorporationUserUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<CorporationUserListPageDTO>(null, null);
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
                ResponseModel<CorporationUserListPageDTO> response = await _baseDAL.GetByFilterAsync<CorporationUserListPageDTO>("CorporationUser/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    CorporationUserListViewModels viewData = new CorporationUserListViewModels(response.Data.TableRows, response.Data.maxPages);


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
        public async Task<IActionResult> AddCorporationUser()
        {
            try
            {
                ResponseModel<CorporationUserAddDTO> response = await _baseDAL.GetByFilterAsync<CorporationUserAddDTO>("CorporationUser/AddCorporation", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    CorporationUserAddViewModels viewData = new CorporationUserAddViewModels(
                        Guid.Empty,
                        0,
                        1,
                        DateTime.Now,
                        DateTime.Now,
                        Guid.Empty,
                        Guid.Empty);


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
        //[ValidateAntiForgeryToken]

        public async Task<IActionResult> AddCorporationUser(CorporationUserAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            CorporationUserAddDTO addDTO = new CorporationUserAddDTO(viewData.BaseUserId, viewData.CorporationId, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<CorporationUserAddDTO, bool>(addDTO, "CorporationUser/AddCorporationUser", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> UpdateCorporationUser(Guid BaseUserId, int CorporationId)
        {
            //string queryString = "CorporationUserId=" + Id;

            ////BaseApi
            //try
            //{
            //    ResponseModel<CorporationUserUpdateDTO> response = await _baseDAL.GetByFilterAsync<CorporationUserUpdateDTO>("Corporation/UpdateCorporation", HttpContext.Session.GetString("userToken"), queryString);

            //    if (response.IsSuccess)
            //    {
            //        CorporationUserUpdateViewModels viewData = new CorporationUserUpdateViewModels(
            //            response.Data.BaseUserId,
            //            response.Data.CorporationId,
            //            response.Data.IsActive,
            //            response.Data.CreatedDate,
            //            response.Data.ModifiedDate,
            //            response.Data.CreatedBy,
            //            response.Data.ModifiedBy);

            //        return View(viewData);
            //    }
            //    else
            //    {
            //        throw new Exception();
            //    }

            //}
            //catch (Exception ex)
            //{
            return RedirectToAction("Index", "Error");
            //}
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateCorporationUser(CorporationUserUpdateViewModels viewData)
        {
            CorporationUserUpdateDTO updateDTO = new CorporationUserUpdateDTO(viewData.BaseUserId, viewData.CorporationId, viewData.IsActive, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<CorporationUserUpdateDTO, bool>(updateDTO, "CorporationUser/UpdateCorporationUser", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> RemoveCorporationUser(Guid BaseUserId, int CorporationId)
        {
            //string queryString = "CorporationId=" + Id;

            ////BaseApi
            //try
            //{
            //    ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "CorporationUser/Delete", HttpContext.Session.GetString("userToken"));

            //    if (response.Data)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        throw new Exception();
            //    }
            //}
            //catch (Exception ex)
            //{
            return RedirectToAction("Index", "Error");
            //}
        }
    }
}
