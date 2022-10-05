using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.ApiService.ApiServices;
using SecondHandCarBidProject.ApiService.Dto_s;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidController : Controller
    {
        BidApiServices _bidApiServices;
        public BidController(BidApiServices bidApiServices)
        {
            _bidApiServices=bidApiServices; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BidAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BidAdd(BidAddDTO bidAddDTO)
        {
            if (String.IsNullOrEmpty(bidAddDTO.CarCode) && String.IsNullOrEmpty(bidAddDTO.CarName))
            {
                await _bidApiServices.BiddAddAsync(bidAddDTO);
            }
            return View();
        }
    }
}
