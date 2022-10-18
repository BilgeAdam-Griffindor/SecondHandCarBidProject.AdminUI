using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class NotaryFeeController : Controller
    {
        private IValidator<NotaryFeeAddDTO> _validatorAdd;
        private IValidator<NotaryFeeUpdateDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public NotaryFeeController(IValidator<NotaryFeeAddDTO> validatorAdd,
            IValidator<NotaryFeeUpdateDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            //var data = await _baseDAL.ListAll<NotaryFeeListPageDTO>(null, null);
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
                ResponseModel<NotaryFeeListPageDTO> response = await _baseDAL.GetByFilterAsync<NotaryFeeListPageDTO>("NotaryFee/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    NotaryFeeListViewModels viewData = new NotaryFeeListViewModels(response.Data.TableRows, response.Data.maxPages);


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
        public async Task<IActionResult> AddNotaryFee()
        {
            try
            {
                ResponseModel<NotaryFeeAddDTO> response = await _baseDAL.GetByFilterAsync<NotaryFeeAddDTO>("CorporationType/AddCorporation", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    NotaryFeeAddViewModels viewData = new NotaryFeeAddViewModels(
                        0,
                        DateTime.Now,
                        DateTime.Now,
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
        public async Task<IActionResult> AddNotaryFee(NotaryFeeAddViewModels viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            NotaryFeeAddDTO addDTO = new NotaryFeeAddDTO(viewData.FeeAmount, viewData.StartDate, viewData.EndDate, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<NotaryFeeAddDTO, bool>(addDTO, "CorporationType/AddCorporationType", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> UpdateNotaryFee(Guid Id)
        {
            string queryString = "CorporationTypeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<NotaryFeeUpdateDTO> response = await _baseDAL.GetByFilterAsync<NotaryFeeUpdateDTO>("NotaryFee/UpdateNotaryFee", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    NotaryFeeUpdateViewModels viewData = new NotaryFeeUpdateViewModels(
                            response.Data.Id,
                            response.Data.FeeAmount,
                            response.Data.StartDate,
                            response.Data.EndDate,
                            response.Data.IsActive,                         
                            response.Data.CreatedDate,
                            response.Data.ModifiedDate,
                            response.Data.CreatedBy,
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
        public async Task<IActionResult> UpdateNotaryFee(NotaryFeeUpdateViewModels viewData)
        {
            NotaryFeeUpdateDTO updateDTO = new NotaryFeeUpdateDTO(viewData.Id, viewData.FeeAmount, viewData.StartDate, viewData.EndDate, viewData.IsActive, viewData.CreatedDate, viewData.ModifiedDate, new Guid(HttpContext.Session.GetString("currentUserId")), viewData.ModifiedBy);

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<NotaryFeeUpdateDTO, bool>(updateDTO, "NotaryFee/UpdateNotaryFee", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> RemoveNotaryFee(Guid Id)
        {
            string queryString = "NotaryFeeId=" + Id;

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "NotaryFee/Delete", HttpContext.Session.GetString("userToken"));

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
