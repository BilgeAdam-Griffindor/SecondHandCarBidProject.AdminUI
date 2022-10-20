using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Logging;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;
using SecondHandCarBidProject.AdminUI.Validator.ActionAuthType;
using SecondHandCarBidProject.AdminUI.Validator.AddressInfo;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AddressInfoController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> logger;
        ILogCatcher cathcLog;
        IBaseDAL service;
        IConfiguration configuration;
        public AddressInfoController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service, IConfiguration _configuration, ILogCatcher _cathcLog)
        {
            logger = _logger;
            service = _service;
            configuration = _configuration;
            cathcLog = _cathcLog;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result = await service.ListAll<AddressInfoSelectDTO>("ApiPath", "Token");
            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddressInfoAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddressInfoAdd(AddressInfoAdd data)
        {
            try
            {
                AddressInfoAddValidator validationRules = new AddressInfoAddValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<AddressInfoAdd, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }

        [HttpGet] 
        public async Task<IActionResult> UpdateAddressInfo(int id)
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result= await service.GetByFilterAsync<AddressInfoUpdateDTO>("ApiPath", "Token",id);

            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddressInfo(AddressInfoUpdateDTO data)
        {
            try
            {
                AddressInfoUpdateValidator validationRules = new AddressInfoUpdateValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.UpdateAsync<AddressInfoUpdateDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
    }
}
 