﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidResultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            BidResultListViewModel model = new BidResultListViewModel();
            model.TableRows = new List<BidResultListTableRowsDTO>();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BidResultAddViewModel viewData = new BidResultAddViewModel();
            viewData.BidOfferList = new List<SelectListItem>();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Add(BidResultAddViewModel viewData)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            BidResultUpdateViewModel viewData = new BidResultUpdateViewModel();

            return View(viewData);
        }

        [HttpPost]
        public IActionResult Update(BidResultUpdateViewModel viewData)
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