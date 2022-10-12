using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidAdditionalFeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BidAdditionalFeeAddDTO data)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(Guid id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(BidAdditionalFeeUpdateDTO data)
        {
            return View();
        }
    }
}
