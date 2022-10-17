using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;
using SecondHandCarBidProject.AdminUI.Validator.AddressInfo;
using SecondHandCarBidProject.AdminUI.Validator.AdvertInfo;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.LogModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AdvertController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> log;
        IBaseServices service;
        public AdvertController(ILoggerFactoryMethod<MongoLogModel> _log, IBaseServices _service)
        {
            log = _log;
            service = _service;
        }
        public async Task<IActionResult> Index()
        {
            try
            {  
                //todo When Api will be ready after that update apipath and token parameters
                //var result=await service.ListAll<AdvertInfoListDto>("ApiPath", "Token");
            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                throw;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdvertAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdvertAdd(AdvertAddDTO data)
        {
            try
            {
                AdvertInfoAddValidator validationRules = new AdvertInfoAddValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<AdvertAddDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                throw;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdvertUpdate(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdvertUpdate(AdvertUpdateDTO data)
        {
            try
            {
                AdvertInfoUpdateValidator validationRules = new AdvertInfoUpdateValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<AdvertUpdateDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                throw;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdvertFavorites()
        {
            return View();
        }
        public async Task<IActionResult> AdvertInformation()
        {
            return View();
        }

        public async Task<IActionResult> TrafficInsuranceInformation()
        {
            return View();
        }

        public async Task<IActionResult> CommissionPage()
        {
            return View();
        }

        public async Task<IActionResult> CarHistory()
        {
            return View();
        }

        public async Task<IActionResult> ReceiverInformations()
        {
            return View();
        }

    }
}
