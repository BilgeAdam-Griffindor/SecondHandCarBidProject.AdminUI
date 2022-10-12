using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarFavoriteController : Controller
    {
        public IActionResult Index()
        {
            CarFavoriteListViewModel carFavoriteList = new CarFavoriteListViewModel(new List<CarFavoriteTableRowDTO>());
            return View(carFavoriteList);
        }
        [HttpGet]
        public IActionResult CarFavoriteAdd()
        {
            CarFavoriteAddViewModel carFavoriteAdd = new CarFavoriteAddViewModel(Guid.Empty, Guid.Empty, new List<SelectListItem>(), new List<SelectListItem>());
            return View(carFavoriteAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarFavoriteAdd(CarFavoriteAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarFavoriteUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarFavoriteUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
