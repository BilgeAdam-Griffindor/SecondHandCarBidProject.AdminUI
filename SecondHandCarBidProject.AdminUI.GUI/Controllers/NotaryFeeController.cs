using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class NotaryFeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNotaryFee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotaryFee(NotaryFeeAddViewModels notaryFeeAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateNotaryFee(Guid Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateNotaryFee(NotaryFeeUpdateViewModels notaryFeeUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveNotaryFee(Guid Id)
        {
            return View();
        }
    }
}
