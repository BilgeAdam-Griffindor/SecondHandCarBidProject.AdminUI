using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CarBuyListViewModel model = new CarBuyListViewModel();
            model.TableRows = new List<CarBuyListTableRowDTO>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarBuyAddViewModel viewData = new CarBuyAddViewModel();
            viewData.FuelTypeList = new List<SelectListItem>();
            viewData.ColorList = new List<SelectListItem>();
            viewData.BrandList = new List<SelectListItem>();
            viewData.ModelList = new List<SelectListItem>();
            viewData.OptionalHardwareList = new List<SelectListItem>();
            viewData.VersionList = new List<SelectListItem>();
            viewData.BodyTypeList = new List<SelectListItem>();
            viewData.GearTypeList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(CarBuyAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            CarBuyUpdateViewModel viewData = new CarBuyUpdateViewModel();
            viewData.FuelTypeList = new List<SelectListItem>();
            viewData.ColorList = new List<SelectListItem>();
            viewData.BrandList = new List<SelectListItem>();
            viewData.ModelList = new List<SelectListItem>();
            viewData.OptionalHardwareList = new List<SelectListItem>();
            viewData.VersionList = new List<SelectListItem>();
            viewData.BodyTypeList = new List<SelectListItem>();
            viewData.GearTypeList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Update(CarBuyUpdateViewModel viewData)
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
