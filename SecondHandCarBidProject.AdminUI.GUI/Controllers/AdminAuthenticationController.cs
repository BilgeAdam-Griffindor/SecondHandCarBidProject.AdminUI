using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AdminAuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
