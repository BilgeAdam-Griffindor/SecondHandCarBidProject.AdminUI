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
            byte[] resim = System.IO.File.ReadAllBytes("C:\\Users\\emre\\source\\repos\\SecondHandCarBidProject.AdminUI\\SecondHandCarBidProject.AdminUI.GUI\\wwwroot\\AdminTemplate\\images\\adminlogo.png");
            string imreBase64Data = Convert.ToBase64String(resim);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            CarImagesTableRowDTO carImagesTableRowDTO = new CarImagesTableRowDTO(Guid.NewGuid(), "Toyota", "Avensis", resim);
            CarImagesListViewModel carImagesList = new CarImagesListViewModel(new List<CarImagesTableRowDTO>() { carImagesTableRowDTO });
            return View(carImagesList);
        }
        [HttpGet]
        public IActionResult CarImagesAdd()
        {
            var carList = new List<SelectListItem>() { new SelectListItem() {
                Text="Mercedes",
                Value="11"
            },new SelectListItem() {
                Text="BMW",
                Value="12"
            },new SelectListItem() {
                Text="Toyota",
                Value="13"
            } };
            CarImagesAddViewModel carImagesAdd = new CarImagesAddViewModel(carList);

            return View(carImagesAdd);
        }
        [HttpPost]
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
