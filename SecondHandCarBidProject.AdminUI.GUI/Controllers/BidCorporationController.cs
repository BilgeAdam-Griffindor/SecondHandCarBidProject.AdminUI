using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SercondHandCarBidProject.Logging.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidCorporationController : Controller
    {
        private IValidator<BidCorporationAddSendDTO> _validatorAdd;
        private IBaseDAL _baseDAL;
        ILogCatcher _logCatcher;

        public BidCorporationController(IValidator<BidCorporationAddSendDTO> validatorAdd, IBaseDAL baseDAL, ILogCatcher logCatcher)
        {
            _logCatcher = logCatcher;
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
                ResponseModel<BidCorporationListPageDTO> response = await _baseDAL.GetByFilterAsync<BidCorporationListPageDTO>("BidCorporation/List", "token", queryString);

                if (response.IsSuccess)
                {
                    BidCorporationListViewModel viewData = new BidCorporationListViewModel(response.Data.TableRows, response.Data.maxPages);


                    return View(viewData);
                }
                else
                {
                    throw new Exception("Başarısız işlem. BidCorporation/Index Kod: ");
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
        public async Task<IActionResult> Add()
        {
            //BaseApi
            try
            {
                ResponseModel<BidCorporationAddPageDTO> response = await _baseDAL.GetByFilterAsync<BidCorporationAddPageDTO>("BidCorporation/AddGet", HttpContext.Session.GetString("userToken"));

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
                    throw new Exception("Başarısız işlem. BidCorporation/Add [GET] Kod: ");
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
                    ResponseModel<bool> response = await _baseDAL.SaveAsync<BidCorporationAddSendDTO, bool>(addDTO, "BidCorporation/AddPost", HttpContext.Session.GetString("userToken"));

                    if (response.Data)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception("Başarısız işlem. BidCorporation/Add [POST] Kod: ");
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
        public async Task<IActionResult> Delete(Guid bidId, int corporationId)
        {
            string queryString = "bidId=" + bidId + "&corporationId=" + corporationId
                + "&modifiedBy=" + HttpContext.Session.GetString("currentUserId");

            //BaseApi
            try
            {
                ResponseModel<bool> response = await _baseDAL.RemoveByFilterAsync<bool>(queryString, "BidCorporation/Delete", HttpContext.Session.GetString("userToken"));

                if (response.Data)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Başarısız işlem. BidCorporation/Delete Kod: ");
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
