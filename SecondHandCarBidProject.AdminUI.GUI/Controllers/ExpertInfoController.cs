using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class ExpertInfoController : Controller
    {
        private IValidator<ExpertInfoAddDTO> _validatorAdd;
        private IValidator<ExpertInfoUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public ExpertInfoController(IValidator<ExpertInfoAddDTO> validatorAdd,
            IValidator<ExpertInfoUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<ExpertInfoListPageDTO>(null, null);
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
                ResponseModel<ExpertInfoListPageDTO> response = await _baseDAL.GetByFilterAsync<ExpertInfoListPageDTO>("ExpertInfo/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    ExpertInfoListViewModels viewData = new ExpertInfoListViewModels(response.Data.TableRows, response.Data.maxPages);


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
        public async Task<IActionResult> AddExpertInfo()
        {
            try
            {
                ResponseModel<ExpertInfoAddPageDTO> response = await _baseDAL.GetByFilterAsync<ExpertInfoAddPageDTO>("ExpertInfo/AddExpertInfo", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    ExpertInfoAddViewModels viewData = new ExpertInfoAddViewModels(
                        "",
                        0,
                        0,
                        0,
                        null,
                        1,
                        "",
                        DateTime.Now,
                        DateTime.Now,
                        Guid.Empty,
                        Guid.Empty,
                        response.Data.AddressInfoList.Select(x => new SelectListItem
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
        public async Task<IActionResult> AddExpertInfo(ExpertInfoAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            ExpertInfoAddDTO addDTO = new ExpertInfoAddDTO(viewData.CentreName, viewData.AddressInfoId, viewData.Longitude, viewData.Latitude, viewData.Picture, viewData.ExpertAddress, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<ExpertInfoAddDTO, bool>(addDTO, "ExpertInfo/AddExpertInfo", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> UpdateExpertInfo(int Id)
        {
            string queryString = "ExpertInfoId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<ExpertInfoUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<ExpertInfoUpdatePageDTO>("ExpertInfo/UpdateExpertInfo", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    ExpertInfoUpdateViewModels viewData = new ExpertInfoUpdateViewModels(
                        response.Data.Id,
                        response.Data.CentreName,
                        response.Data.AddressInfoId,
                        response.Data.Longitude,
                        response.Data.Latitude,
                        response.Data.Picture,
                        response.Data.IsActive,
                        response.Data.ExpertAddress,
                        response.Data.CreatedDate,
                        response.Data.ModifiedDate,
                        response.Data.CreatedBy,
                        response.Data.ModifiedBy,
                        response.Data.AddressInfoList.Select(x => new SelectListItem
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
        public async Task<IActionResult> UpdateExpertInfo(ExpertInfoUpdateViewModels viewData)
        {
            ExpertInfoUpdateDTO updateDTO = new ExpertInfoUpdateDTO(viewData.Id, viewData.CentreName, viewData.AddressInfoId, viewData.Longitude, viewData.Latitude, viewData.Picture, viewData.IsActive, viewData.ExpertAddress, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<ExpertInfoUpdateDTO, bool>(updateDTO, "ExpertInfo/UpdateExpertInfo", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> RemoveExpertInfo(int Id)
        {
            string queryString = "ExpertInfoId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "ExpertInfo/Delete", HttpContext.Session.GetString("userToken"));

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
