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
    public class BidCorporationController : Controller
    {
        private IValidator<BidCorporationAddSendDTO> _validatorAdd;
        private IBaseDAL _baseDAL;

        public BidCorporationController(IValidator<BidCorporationAddSendDTO> validatorAdd, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
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
                ResponseModel<BidCorporationListPageDTO> response = await _baseDAL.GetByFilterAsync<BidCorporationListPageDTO>("BidCorporation/List", HttpContext.Session.GetString("userToken"), queryString);

                if (response.IsSuccess)
                {
                    BidCorporationListViewModel viewData = new BidCorporationListViewModel(response.Data.TableRows, response.Data.maxPages);


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
                ResponseModel<BidCorporationAddPageDTO> response = await _baseDAL.GetByFilterAsync<BidCorporationAddPageDTO>("BidCorporation/Add", HttpContext.Session.GetString("userToken"));

                if (response.IsSuccess)
                {
                    BidCorporationAddViewModel viewData = new BidCorporationAddViewModel(
                        Guid.Empty,
                        0,
                        response.Data.BidList.Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        }).ToList(),
                        response.Data.CorporationList.Select(x => new SelectListItem
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
        public async Task<IActionResult> Add(BidCorporationAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            BidCorporationAddSendDTO addDTO = new BidCorporationAddSendDTO(viewData.BidId, viewData.CorporationId, new Guid(HttpContext.Session.GetString("currentUserId")));

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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<BidCorporationAddSendDTO, bool>(addDTO, "BidCorporation/Add", HttpContext.Session.GetString("userToken"));

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
        public async Task<IActionResult> Delete(Guid bidId, int corporationId)
        {
            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveAsync<bool>(bidId + "&corporationId="+corporationId, "BidStatusHistory/Delete", HttpContext.Session.GetString("userToken"));

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
