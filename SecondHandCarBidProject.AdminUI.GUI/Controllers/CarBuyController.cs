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
            CarBuyListViewModel model = new CarBuyListViewModel(0, new List<SelectListItem>(), 0, new List<SelectListItem>(), 0, new List<SelectListItem>(), new List<CarBuyListTableRowDTO>(), 0, 0);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarBuyAddViewModel viewData = new CarBuyAddViewModel(0, 0, "", 0, 0, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, new List<Guid>(), "", new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>());

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
            CarBuyUpdateViewModel viewData = new CarBuyUpdateViewModel(Guid.Empty, Guid.Empty, "", 0, 0, 0, 0, "", 0, 0, 0, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, new List<Guid>(), "", new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>(), new List<SelectListItem>());

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
