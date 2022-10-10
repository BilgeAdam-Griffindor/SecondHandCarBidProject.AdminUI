using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidStatusHistoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            BidStatusHistoryListViewModel model = new BidStatusHistoryListViewModel();
            model.TableRows = new List<BidStatusHistoryListTableRowsDTO>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BidStatusHistoryAddViewModel viewData = new BidStatusHistoryAddViewModel();
            viewData.BidList = new List<SelectListItem>();
            viewData.StatusValueList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(BidStatusHistoryAddViewModel viewData)
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
