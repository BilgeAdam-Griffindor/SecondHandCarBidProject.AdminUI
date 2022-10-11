using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidCorporationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            BidCorporationListViewModel model = new BidCorporationListViewModel(new List<BidCorporationListTableRowsDTO>());

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BidCorporationAddViewModel viewData = new BidCorporationAddViewModel(Guid.Empty, 0, new List<SelectListItem>(), new List<SelectListItem>());

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(BidCorporationAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid bidId, int corporationId)
        {
            return View();
        }
    }
}
