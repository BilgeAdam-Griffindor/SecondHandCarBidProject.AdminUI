﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class CarBuyStatusHistoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CarBuyStatusHistoryListViewModel model = new CarBuyStatusHistoryListViewModel();
            model.TableRows = new List<CarBuyStatusHistoryTableRow>();

            return View(model);
        }

        [HttpGet] 
        public IActionResult Add()
        {
            CarBuyStatusHistoryAddViewModel viewData = new CarBuyStatusHistoryAddViewModel();
            viewData.CarBuyList = new List<SelectListItem>();
            viewData.StatusValueList = new List<SelectListItem>();


            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(CarBuyStatusHistoryAddViewModel viewData)
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