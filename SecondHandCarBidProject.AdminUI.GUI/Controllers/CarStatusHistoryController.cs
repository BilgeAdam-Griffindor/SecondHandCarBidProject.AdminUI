using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarStatusHistoryController : Controller
    {
        public IActionResult Index()
        {
            CarStatusHistoryListViewModel carStatusHistoryList = new CarStatusHistoryListViewModel(new List<CarStatusHistoryTableRowDTO>());
            return View(carStatusHistoryList);
        }
        [HttpGet]
        public IActionResult CarStatusHistoryAdd()
        {
            CarStatusHistoryAddViewModel carStatusHistoryAdd = new CarStatusHistoryAddViewModel(Guid.Empty, 0, "", new List<SelectListItem>(), new List<SelectListItem>());
            return View(carStatusHistoryAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarStatusHistoryAdd(CarStatusHistoryAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarStatusHistoryUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarStatusHistoryUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
