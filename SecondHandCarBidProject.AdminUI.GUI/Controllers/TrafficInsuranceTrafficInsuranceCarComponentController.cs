using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class TrafficInsuranceTrafficInsuranceCarComponentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
    }
}
