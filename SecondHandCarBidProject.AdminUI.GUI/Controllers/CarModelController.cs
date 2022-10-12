using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarModelController : Controller
    {
        public IActionResult Index()
        {
            CarModelListViewModel carModelList = new CarModelListViewModel(new List<CarModelTableRowDTO>());
            return View(carModelList);
        }
        [HttpGet]
        public IActionResult CarModelAdd()
        {
            CarModelAddViewModel carModelAdd = new CarModelAddViewModel(1, "", new List<SelectListItem>());
            return View(carModelAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarModelAdd(CarModelAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarModelUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarModelUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
