using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CommissionFeeController : Controller
    {
        public IActionResult Index()
        {
            CommissionFeeListViewModel commissionFeeList = new CommissionFeeListViewModel(new List<CommissionFeeTableRowDTO>());
            return View(commissionFeeList);
        }
        [HttpGet]
        public IActionResult CommissionFeeAdd()
        {
            CommissionFeeAddViewModel commissionFeeAdd = new CommissionFeeAddViewModel(0, 0, 0, DateTime.Now, DateTime.Now);
            return View(commissionFeeAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommissionFeeAdd(CommissionFeeAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CommissionFeeUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommissionFeeUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
