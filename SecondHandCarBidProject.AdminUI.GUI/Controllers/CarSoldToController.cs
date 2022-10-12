using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarSoldToController : Controller
    {
        public IActionResult Index()
        {
            CarSoldToListViewModel carSoldToList = new CarSoldToListViewModel(new List<CarSoldToTableRowDTO>());
            return View(carSoldToList);
        }
        [HttpGet]
        public IActionResult CarSoldToAdd()
        {
            CarSoldToAddViewModel carSoldToAdd = new CarSoldToAddViewModel(Guid.Empty, Guid.Empty, 0, new List<SelectListItem>(), new List<SelectListItem>());
            return View(carSoldToAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarSoldToAdd(CarSoldToAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarSoldToUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarSoldToUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
