using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyStatusHistoryController : Controller
    {
        private IValidator<CarBuyStatusHistoryAddSendDTO> _validatorAdd;
        private IBaseServices _baseService;

        public CarBuyStatusHistoryController(IValidator<CarBuyStatusHistoryAddSendDTO> validatorAdd)
        {
            _validatorAdd = validatorAdd;
            //_baseService = baseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CarBuyStatusHistoryListViewModel model = new CarBuyStatusHistoryListViewModel(new List<CarBuyStatusHistoryTableRow>());

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarBuyStatusHistoryAddViewModel viewData = new CarBuyStatusHistoryAddViewModel(Guid.Empty, 0, "", new List<SelectListItem>(), new List<SelectListItem>());


            return View(viewData);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarBuyStatusHistoryAddViewModel viewData)
        {
            //Convert to send dto (Possibly inefficient to convert before validation)
            //CarBuyStatusHistoryAddSendDTO addDTO = new CarBuyStatusHistoryAddSendDTO(viewData.CarBuyId, viewData.StatusValueId, viewData.Explanation, new Guid(HttpContext.Session.GetString("currentUserId")));
            CarBuyStatusHistoryAddSendDTO addDTO = new CarBuyStatusHistoryAddSendDTO(viewData.CarBuyId, viewData.StatusValueId, viewData.Explanation, Guid.Empty);

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
                    //_baseService.SaveAsync()
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
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View();
        }
    }
}
