using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidOfferController : Controller
    {
        private IValidator<BidOfferAddSendDTO> _validatorAdd;
        private IValidator<BidOfferUpdateSendDTO> _validatorUpdate;
        private IBaseDAL _baseDAL;

        public BidOfferController(IValidator<BidOfferAddSendDTO> validatorAdd, IValidator<BidOfferUpdateSendDTO> validatorUpdate, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
            _baseDAL = baseDAL;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int itemPerPage = 100)
        {
            ViewData["page"] = page;
            ViewData["itemPerPage"] = itemPerPage;

            string queryString = "page=" + page + "&itemPerPage=" + itemPerPage;

            //BaseApi
            try
            {
                ResponseModel<BidOfferListPageDTO> response = await _baseDAL.GetByFilterAsync<BidOfferListPageDTO>("BidOffer/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    BidOfferListViewModel viewData = new BidOfferListViewModel(response.Data.TableRows, response.Data.maxPages);


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
        public async Task<IActionResult> Add()
        {
            //BaseApi
            try
            {
                ResponseModel<BidOfferAddPageDTO> response = await _baseDAL.GetByFilterAsync<BidOfferAddPageDTO>("BidOffer/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    BidOfferAddViewModel viewData = new BidOfferAddViewModel(
                        0,
                        Guid.Empty,
                        Guid.Empty,
                        "",
                        response.Data.BaseUserList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.BidList.Select(x => new SelectListItem
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
        public async Task<IActionResult> Add(BidOfferAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            BidOfferAddSendDTO addDTO = new BidOfferAddSendDTO(0, viewData.BaseUserId, viewData.BidId, viewData.Explanation, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<BidOfferAddSendDTO, bool>(addDTO, "BidOffer/Add", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> Update(Guid id)
        {
            string queryString = "bidResultId=" + id;

            //BaseApi
            try
            {
                ResponseModel<BidOfferUpdatePageDTO> response = await _baseDAL.GetByFilterAsync<BidOfferUpdatePageDTO>("BidOffer/Update", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    BidOfferUpdateViewModel viewData = new BidOfferUpdateViewModel(
                        response.Data.Id, 
                        response.Data.OfferAmount, 
                        response.Data.BaseUserId, 
                        response.Data.BidId, 
                        response.Data.Explanation,
                        response.Data.BaseUserList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.BidList.Select(x => new SelectListItem
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
        public async Task<IActionResult> Update(BidOfferUpdateViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            BidOfferUpdateSendDTO updateDTO = new BidOfferUpdateSendDTO(viewData.Id, 0, viewData.BaseUserId, viewData.BidId, viewData.Explanation, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.UpdateAsync<BidOfferUpdateSendDTO, bool>(updateDTO, "BidOffer/Update", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> Delete(Guid id)
        {
            string queryString = "bidOfferId=" + id;
            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveAsync<bool>(queryString, "BidOffer/Delete", HttpContext.Session.GetString("userToken"));

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
