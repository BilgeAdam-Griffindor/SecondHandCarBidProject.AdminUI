using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BidCarAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BidCarAdd(BidCarAddDTO data)
        {
            return View();
        }
    }
}
