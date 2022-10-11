using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarImagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CarImagesAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarImagesAdd(RolePageActionAuthAddDto data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarImagesUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarImagesUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
