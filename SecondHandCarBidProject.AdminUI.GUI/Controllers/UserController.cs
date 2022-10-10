using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserAdd(BaseUserAddDTO data)
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserUpdate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserUpdate(BaseUserUpdateDTO data)
        {
            return View();
        }
    }
}
