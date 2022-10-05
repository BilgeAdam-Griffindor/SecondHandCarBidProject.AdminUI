using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
