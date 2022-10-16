using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CarListPageDTO carListPageDTO = new CarListPageDTO(null, null, null, null);

            CarListViewModel carListViewModel = new CarListViewModel(0 , new List<SelectListItem>(), 0, new List<SelectListItem>(), 0, new List<SelectListItem>(), new List<CarListTableRowDTO>(), 0, 0);


            return View(carListViewModel);
        }

        [HttpPost]
        public IActionResult Index(CarListViewModel carListView)
        {
            string queryString = "";

            if (carListView.BrandId != null)
                queryString += "brandId=" + carListView.BrandId;
            if (carListView.ModelId != null)
                queryString += (queryString != "" ? "&" : "") + "modelId=" + carListView.ModelId;
            if (carListView.StatusId != null)
                queryString += (queryString != "" ? "&" : "") + "statusId=" + carListView.StatusId;

            CarListPageDTO carListPageDTO = new CarListPageDTO(null, null, null, null);

            CarListViewModel carListViewModel = new CarListViewModel(0, new List<SelectListItem>(), 0, new List<SelectListItem>(), 0, new List<SelectListItem>(), new List<CarListTableRowDTO>(), carListView.Page, carListView.ItemPerPage);

            return View(carListViewModel);
        }

        [HttpGet]
        public IActionResult DeleteCar(string id)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CarDetailInformation()
        {
            CarDetailAddDto carDetailDto = new CarDetailAddDto();
            //carDetailDto.selectItemList = new List<SelectListItem> { new SelectListItem { Text = "Bireysel", Value = "1" }, new SelectListItem { Text = "Kurumsal", Value = "2" } };
            carDetailDto.BireyselKurumsalListe = new List<SelectListItem>
            {
                new SelectListItem{ Text="Bireysel", Value="0"},
                new SelectListItem{ Text="Kurumsal", Value="2"},
            };

            return View(carDetailDto);
        }

        [HttpPost]
        public IActionResult CarDetailInformation(CarDetailAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCar(string id)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCar(CarDetailUpdateViewModel viewData)
        {
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CarSave()//CarDTO carDTO
        {

            return View();
        }
    }
}
