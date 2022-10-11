using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyAdditionalFeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CarBuyAdditionalFeeListViewModel model = new CarBuyAdditionalFeeListViewModel();
            model.TableRows = new List<CarBuyAdditionalFeeTableRowDTO>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarBuyAdditionalFeeAddViewModel viewData = new CarBuyAdditionalFeeAddViewModel();
            viewData.CarBuyList = new List<SelectListItem>();
            viewData.NotaryFeeList = new List<SelectListItem>();
            viewData.CommissionFeeList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(CarBuyAdditionalFeeAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View();
        }
    }
}
