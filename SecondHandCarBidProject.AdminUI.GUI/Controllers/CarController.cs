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
            //TODO Lists might be cached to avoid requesting same lists again and again
            //TODO call api and get response as CarListPageDTO
            CarListPageDTO carListPageDTO = new CarListPageDTO(null, null, null, null);

            //Convert response to ViewModel
            CarListViewModel carListViewModel = new CarListViewModel();
            carListViewModel.CarTableRows = new List<CarListTableRowDTO>();

            //TODO which is better?
            //carListViewModel.CarTableRows = carListPageDTO.CarTableRows; //Method 1
            //carListViewModel.CarTableRows = new List<CarListTableRowDTO>(carListPageDTO.CarTableRows); //Method 2

            //TODO Add try catch for EACH list
            carListViewModel.BrandList = new List<SelectListItem>();
            //carListViewModel.BrandList = carListPageDTO.BrandList.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();

            carListViewModel.ModelList = new List<SelectListItem>();
            //carListViewModel.ModelList = carListPageDTO.ModelList.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();

            carListViewModel.StatusList = new List<SelectListItem>();
            //carListViewModel.StatusList = carListPageDTO.StatusList.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();

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


            //TODO Lists might be cached and then we just need to get the filtered items
            //TODO call api and get response as CarListPageDTO, this time with queryString as filter
            CarListPageDTO carListPageDTO = new CarListPageDTO(null, null, null, null);

            //Convert response to ViewModel
            CarListViewModel carListViewModel = new CarListViewModel();
            carListViewModel.Page = carListView.Page;
            carListViewModel.ItemPerPage = carListView.ItemPerPage;

            //TODO which is better?
            carListViewModel.CarTableRows = carListPageDTO.CarTableRows; //Method 1
            //carListViewModel.CarTableRows = new List<CarListTableRowDTO>(carListPageDTO.CarTableRows); //Method 2

            carListViewModel.BrandList = carListPageDTO.BrandList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            carListViewModel.ModelList = carListPageDTO.ModelList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            carListViewModel.StatusList = carListPageDTO.StatusList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(carListViewModel);
        }

        [HttpGet]
        public IActionResult DeleteCar(string id)
        {
            //TODO Call api for delete
            //TODO Filter lost
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCar(string id)
        {
            //TODO Call api for update
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
        public IActionResult CarDetailInformation(string deneme)
        {
            return View();
        }

        public async Task<IActionResult> CarSave()//CarDTO carDTO
        {

            return View();
        }
    }
}
