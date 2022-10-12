using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarPropertValueController : Controller
    {
        public IActionResult Index()
        {
            CarPropertyValueListViewModel carPropertyValueList = new CarPropertyValueListViewModel(new List<CarPropertyValueTableRowDTO>());
            return View(carPropertyValueList);
        }
        [HttpGet]
        public IActionResult CarPropertValueAdd()
        {
            CarPropertyValueAddViewModel carPropertyValueAdd = new CarPropertyValueAddViewModel("", Guid.Empty, new List<SelectListItem>());
            return View(carPropertyValueAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertValueAdd(CarPropertyValueAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarPropertValueUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertValueUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
