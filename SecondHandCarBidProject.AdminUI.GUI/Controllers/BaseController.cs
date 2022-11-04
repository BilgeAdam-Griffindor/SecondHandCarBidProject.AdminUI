using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult BaseAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BaseAdd(ExampleDTO exampleDTO)
        {
            return View();
        }

    }
}
