using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidOfferController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            BidOfferListViewModel model = new BidOfferListViewModel();
            model.TableRows = new List<BidOfferListTableRowsDTO>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BidOfferAddViewModel viewData = new BidOfferAddViewModel();
            viewData.BidList = new List<SelectListItem>();
            viewData.BaseUserList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(BidOfferAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            BidOfferUpdateViewModel viewData = new BidOfferUpdateViewModel();
            viewData.BidList = new List<SelectListItem>();
            viewData.BaseUserList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Update(BidOfferUpdateViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return View();
        }
    }
}
