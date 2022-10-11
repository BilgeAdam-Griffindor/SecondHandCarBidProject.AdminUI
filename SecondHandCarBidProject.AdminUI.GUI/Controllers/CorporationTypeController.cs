using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporationTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCorporationType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCorporationType(CorporationTypeAddViewModels corporationTypeAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCorporationType(int Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCorporationType(CorporationTypeUpdateViewModels corporationTypeUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveCorporationType(int Id)
        {
            return View();
        }
    }
}
