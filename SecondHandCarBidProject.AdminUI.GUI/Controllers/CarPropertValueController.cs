using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarPropertValueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CarPropertValueAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertValueAdd(RolePageActionAuthAddDto data)
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
