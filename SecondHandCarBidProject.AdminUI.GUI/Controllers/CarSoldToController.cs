using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarSoldToController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CarSoldToAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarSoldToAdd(RolePageActionAuthAddDto data)
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
