using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarFavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CarFavoriteAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarFavoriteAdd(RolePageActionAuthAddDto data)
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
