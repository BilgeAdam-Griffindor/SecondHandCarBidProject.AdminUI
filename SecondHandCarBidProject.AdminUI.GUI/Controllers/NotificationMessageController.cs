using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class NotificationMessageController : Controller
    {
        private IValidator<NotificationMessageAddDTO> _validatorAdd;
        private IValidator<NotificationMessageUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public NotificationMessageController(IValidator<NotificationMessageAddDTO> validatorAdd,
            IValidator<NotificationMessageUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<NotificationMessageListPageDTO>(null, null);
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
                ResponseModel<NotificationMessageListPageDTO> response = await _baseDAL.GetByFilterAsync<NotificationMessageListPageDTO>("NotificationMessage/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    NotificationMessageListViewModels viewData = new NotificationMessageListViewModels(response.Data.TableRows, response.Data.maxPages);


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
        public async Task<IActionResult> AddNotificationMessage()
        {
            try
            {
                ResponseModel<NotificationMessageAddDTO> response = await _baseDAL.GetByFilterAsync<NotificationMessageAddDTO>("NotificationMessage/AddNotificationMessage", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    NotificationMessageAddViewModels viewData = new NotificationMessageAddViewModels(
                        "",
                        1,
                        DateTime.Now,
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

        public async Task<IActionResult> AddNotificationMessage(NotificationMessageAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            NotificationMessageAddDTO addDTO = new NotificationMessageAddDTO(viewData.Content, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<NotificationMessageAddDTO, bool>(addDTO, "NotificationMessage/AddNotificationMessage", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> UpdateNotificationMessage(int Id)
        {
            string queryString = "NotificationMessageId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<NotificationMessageUpdateDTO> response = await _baseDAL.GetByFilterAsync<NotificationMessageUpdateDTO>("NotificationMessage/UpdateNotificationMessage", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    NotificationMessageUpdateViewModels viewData = new NotificationMessageUpdateViewModels(
                        response.Data.Id,
                        response.Data.Content,
                        response.Data.IsActive,
                        response.Data.ModifiedDate,
                        response.Data.ModifiedBy);

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
        public async Task<IActionResult> UpdateNotificationMessage(NotificationMessageUpdateViewModels viewData)
        {
            NotificationMessageUpdateDTO updateDTO = new NotificationMessageUpdateDTO(viewData.Id, viewData.Content, viewData.IsActive, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<NotificationMessageUpdateDTO, bool>(updateDTO, "NotificationMessage/UpdateNotificationMessage", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> RemoveNotificationMessage(int Id)
        {
            string queryString = "NotificationMessageId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "NotificationMessage/Delete", HttpContext.Session.GetString("userToken"));

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
