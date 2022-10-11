using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class PageAuthTypeController : Controller
    {
        
        [HttpGet]
        public IActionResult Index(string id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(string id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            return View();
        }
    }
}
