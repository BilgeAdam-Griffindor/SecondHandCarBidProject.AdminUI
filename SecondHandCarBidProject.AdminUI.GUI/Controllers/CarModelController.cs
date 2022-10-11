using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CarModelAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarModelAdd(RolePageActionAuthAddDto data)
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
