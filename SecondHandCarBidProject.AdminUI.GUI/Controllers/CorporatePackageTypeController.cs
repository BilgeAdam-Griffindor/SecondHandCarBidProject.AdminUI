using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporatePackageTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCorporatePackageType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCorporatePackageType(CorporatePackageTypeAddViewModels corporatePackageTypeAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCorporatePackageType(Int16 Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCorporatePackageType(CorporatePackageTypeUpdateViewModels corporatePackageTypeUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveCorporatePackageType(Int16 Id)
        {
            return View();
        }
    }
}
