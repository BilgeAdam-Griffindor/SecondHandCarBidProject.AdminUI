using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarCorporationController : Controller
    {
        public IActionResult Index()
        {
            CarCorporationListViewModel carCorporationList = new CarCorporationListViewModel(new List<CarCorporationTableRowDTO>());
            return View(carCorporationList);
        }
        [HttpGet]
        public IActionResult CarCorporationAdd()
        {
            CarCorporationAddViewModel carCorporationAdd = new CarCorporationAddViewModel(Guid.Empty, Guid.Empty, new List<SelectListItem>(), new List<SelectListItem>());
            return View(carCorporationAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarCorporationAdd(CarCorporationAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarCorporationUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarCorporationUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
