using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarImagesController : Controller
    {
        public IActionResult Index()
        {
            CarImagesListViewModel carImagesList = new CarImagesListViewModel(new List<CarImagesTableRowDTO>());
            return View(carImagesList);
        }
        [HttpGet]
        public IActionResult CarImagesAdd()
        {
            CarImagesAddViewModel carImagesAdd = new CarImagesAddViewModel(Guid.Empty, null, new List<SelectListItem>());
            return View(carImagesAdd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarImagesAdd(CarImagesAddViewModel data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarImagesUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarImagesUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
