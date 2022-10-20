using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarPropertyController : Controller
    {
        private IValidator<CarPropertyAddSendDTO> _validatorAdd;
        private IBaseDAL _baseDAL;

        public CarPropertyController(IValidator<CarPropertyAddSendDTO> validatorAdd, IBaseDAL baseDAL)
        {
            _validatorAdd = validatorAdd;
            _baseDAL = baseDAL;
        }
        public IActionResult Index()
        {
            CarPropertyListViewModel carPropertyList = new CarPropertyListViewModel(new List<CarPropertyTableRowDTO>());
            return View(carPropertyList);

        }
        [HttpGet]
        public IActionResult CarPropertyAdd()
        {
            CarPropertyAddViewModel carPropertyAdd = new CarPropertyAddViewModel(Guid.Empty, Guid.Empty, new List<SelectListItem>(), new List<SelectListItem>());
            return View(carPropertyAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertyAdd(CarPropertyAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarPropertyUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarPropertyUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
