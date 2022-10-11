using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CorporationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCorporationUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCorporationUser(CorporationUserAddViewModels corporationUserAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCorporationUser(Guid BaseUserId, int CorporationId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCorporationUser(CorporationUserUpdateViewModels corporationUserUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveCorporationUser(Guid BaseUserId, int CorporationId)
        {
            return View();
        }
    }
}
