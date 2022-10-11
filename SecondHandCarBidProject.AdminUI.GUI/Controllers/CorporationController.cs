using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCorporation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCCorporation(CorporationAddViewModels corporationAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCorporation(int Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCorporation(CorporationUpdateViewModels corporationUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveCorporation(int Id)
        {
            return View();
        }
    }
}
