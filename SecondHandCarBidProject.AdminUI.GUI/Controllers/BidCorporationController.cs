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
            BidCorporationListViewModel model = new BidCorporationListViewModel();
            model.TableRows = new List<BidCorporationListTableRowsDTO>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BidCorporationAddViewModel viewData = new BidCorporationAddViewModel();
            viewData.CorporationList = new List<SelectListItem>();
            viewData.BidList = new List<SelectListItem>();

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
