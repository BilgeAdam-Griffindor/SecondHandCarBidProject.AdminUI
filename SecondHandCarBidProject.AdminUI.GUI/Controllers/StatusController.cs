using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Type()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Type(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult TypeAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TypeUpdate(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Value()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ValueAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValueUpdate(string id)
        {
            return View();
        }


    }
}
