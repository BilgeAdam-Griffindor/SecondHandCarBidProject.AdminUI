using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBrandController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CarBrandListViewModel model = new CarBrandListViewModel(new List<CarBrandListTableRow>());

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CarBrandAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(short id)
        {
            CarBrandUpdateViewModel viewData = new CarBrandUpdateViewModel(0, "");
            return View(viewData);
        }

        [HttpPost]
        public IActionResult Update(CarBrandUpdateViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
