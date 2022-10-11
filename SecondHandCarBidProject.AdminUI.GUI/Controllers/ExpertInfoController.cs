using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class ExpertInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddExpertInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExpertInfo(ExpertInfoAddViewModels expertInfoAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateExpertInfo(int Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateExpertInfo(ExpertInfoUpdateViewModels expertInfoUpdateView)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveExpertInfo(int Id)
        {
            return View();
        }
    }
}
