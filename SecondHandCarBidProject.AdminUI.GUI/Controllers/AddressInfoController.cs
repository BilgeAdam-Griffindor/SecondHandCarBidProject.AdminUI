using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AddressInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       
        public IActionResult AddressInfoAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddressInfoAdd(AddressInfoAdd data)
        {
            return View();
        }

        [HttpGet] 
        public IActionResult UpdateAddressInfo(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAddressInfo(AddressInfoAdd data)
        {
            return View();
        }
    }
}
