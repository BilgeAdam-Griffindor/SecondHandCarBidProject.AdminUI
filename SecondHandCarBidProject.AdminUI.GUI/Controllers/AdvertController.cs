using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AdvertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdvertAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdvertAdd(AdvertAddDTO data)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdvertUpdate(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdvertFavorites()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdvertUpdate(AdvertUpdateDTO data)
        {
            return View();
        }
        public IActionResult AdvertInformation()
        {
            return View();
        }

        public IActionResult TrafficInsuranceInformation()
        {
            return View();
        }

        public IActionResult CommissionPage()
        {
            return View();
        }

        public IActionResult CarHistory()
        {
            return View();
        }

        public IActionResult ReceiverInformations()
        {
            return View();
        }

    }
}
