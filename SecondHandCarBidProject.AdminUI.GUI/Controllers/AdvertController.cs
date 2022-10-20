using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;
using SecondHandCarBidProject.AdminUI.Validator.AddressInfo;
using SecondHandCarBidProject.AdminUI.Validator.AdvertInfo;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AdvertController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> logger;
        ILogCatcher cathcLog;
        IBaseDAL service;
        IConfiguration configuration;
        public AdvertController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service, IConfiguration _configuration, ILogCatcher _cathcLog)
        {
            logger = _logger;
            service = _service;
            configuration = _configuration;
            cathcLog = _cathcLog;
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
                await cathcLog.WriteLogWarning(ex);
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
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdvertUpdate(int id)
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result= await service.GetByFilterAsync<AdvertUpdateDTO>("ApiPath", "Token",id);

            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
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
                    //await service.UpdateAsync<AdvertUpdateDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
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
