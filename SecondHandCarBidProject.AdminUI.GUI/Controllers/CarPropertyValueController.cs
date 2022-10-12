using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarPropertyValueController : Controller
    {
        public IActionResult Index()
        {
            CarPropertyValueListViewModel carPropertyValueList = new CarPropertyValueListViewModel(new List<CarPropertyValueTableRowDTO>());
            return View(carPropertyValueList);
        }
        [HttpGet]
        public IActionResult CarPropertyValueAdd()
        {
            CarPropertyValueAddViewModel carPropertyValueAdd = new CarPropertyValueAddViewModel("", Guid.Empty, new List<SelectListItem>());
            return View(carPropertyValueAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertyValueAdd(CarPropertyValueAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarPropertyValueUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertyValueUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
