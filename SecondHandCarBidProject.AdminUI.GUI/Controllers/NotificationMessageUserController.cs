using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class NotificationMessageUserController : Controller
    {
        private IValidator<NotificationMessageUserAddDTO> _validatorAdd;
        private IValidator<NotificationMessageUserUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public NotificationMessageUserController(IValidator<NotificationMessageUserAddDTO> validatorAdd,
            IValidator<NotificationMessageUserUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<NotificationMessageUserListPageDTO>(null, null);
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
                ResponseModel<NotificationMessageUserListPageDTO> response = await _baseDAL.GetByFilterAsync<NotificationMessageUserListPageDTO>("NotificationMessageUser/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    NotificationMessageUserListViewModels viewData = new NotificationMessageUserListViewModels(response.Data.TableRows, response.Data.maxPages);


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
        public async Task<IActionResult> AddNotificationMessageUser()
        {
            try
            {
                ResponseModel<NotificationMessageUserAddPageDTO> response = await _baseDAL.GetByFilterAsync<NotificationMessageUserAddPageDTO>("NotificationMessageUser/AddNotificationMessageUser", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    NotificationMessageUserAddViewModels viewData = new NotificationMessageUserAddViewModels(
                        0,
                        Guid.Empty,
                        1,
                        DateTime.Now,
                        Guid.Empty,
                         response.Data.CreatedByList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList(),
                        response.Data.NotificationMessageList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.SendToBaseUserList.Select(x => new SelectListItem
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
        public async Task<IActionResult> AddNotificationMessageUser(NotificationMessageUserAddViewModels viewData)
        {//Convert to send dto (Possibly inefficient to convert before validation)
            NotificationMessageUserAddDTO addDTO = new NotificationMessageUserAddDTO(viewData.NotificationMessageId, viewData.SendToBaseUserId, viewData.CreatedDate, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<NotificationMessageUserAddDTO, bool>(addDTO, "NotificationMessageUser/AddNotificationMessageUser", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> UpdateNotificationMessageUser(Guid Id)
        {
            string queryString = "NotificationMessageId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<NotificationMessageUserUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<NotificationMessageUserUpdatePageDTO>("NotificationMessageUser/UpdateNotificationMessageUser", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    NotificationMessageUserUpdateViewModels viewData = new NotificationMessageUserUpdateViewModels(
                        response.Data.Id,
                        response.Data.NotificationMessageId,
                        response.Data.SendToBaseUserId,
                        response.Data.IsActive,
                        response.Data.CreatedDate,
                        response.Data.CreatedBy,
                         response.Data.CreatedByList.Select(x => new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name
                         }).ToList(),
                        response.Data.NotificationMessageList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.SendToBaseUserList.Select(x => new SelectListItem
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
        public async Task<IActionResult> UpdateNotificationMessageUser(NotificationMessageUserUpdateViewModels viewData)
        {
            NotificationMessageUserUpdateDTO updateDTO = new NotificationMessageUserUpdateDTO(viewData.Id, viewData.NotificationMessageId, viewData.SendToBaseUserId, viewData.IsActive, viewData.CreatedDate, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<NotificationMessageUserUpdateDTO, bool>(updateDTO, "NotificationMessageUser/UpdateNotificationMessageUser", HttpContext.Session.GetString("userToken"));

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

        public async Task<IActionResult> RemoveNotificationMessageUser(Guid Id)
        {

            string queryString = "NotificationMessageUserId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "NotificationMessageUser/Delete", HttpContext.Session.GetString("userToken"));

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
