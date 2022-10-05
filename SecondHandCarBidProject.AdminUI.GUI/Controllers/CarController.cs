using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CarDetailInformation()
        {
            CarDetailDto carDetailDto = new CarDetailDto();
            //carDetailDto.selectItemList = new List<SelectListItem> { new SelectListItem { Text = "Bireysel", Value = "1" }, new SelectListItem { Text = "Kurumsal", Value = "2" } };
            carDetailDto.BireyselKurumsalListe = new List<SelectListItem>
            {
                new SelectListItem{ Text="Bireysel", Value="0"},
                new SelectListItem{ Text="Kurumsal", Value="2"},
            };

            return View(carDetailDto);
        }
        [HttpPost]
        public IActionResult CarDetailInformation(string deneme)
        {
            return View();
        }
    }
}
