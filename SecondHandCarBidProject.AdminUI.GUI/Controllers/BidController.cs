using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using SecondHandCarBidProject.AdminUI.Validator.Bid;
using SecondHandCarBidProject.AdminUI.Validator.User;
using SecondHandCarBidProject.ApiService.ApiServices;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> logger;
        ILogCatcher cathcLog;
        IBaseDAL service;
        IConfiguration configuration;
        public BidController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service, IConfiguration _configuration, ILogCatcher _cathcLog)
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
                //var result = await service.ListAll<BidSelectDTO>("ApiPath", "Token");
            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BidAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BidAdd(BidAddDto data)
        {
            try
            {
                BidAddValidator validationRules = new BidAddValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<BidAddDto, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BidUpdate(Guid id)
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result= await service.GetByFilterAsync<BidUpdateDTO>("ApiPath", "Token",id);

            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BidUpdate(BidUpdateDTO data)
        {
            try
            {
                BidUpdateValidator validationRules = new BidUpdateValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    // await service.UpdateAsync<BidUpdateDTO, Task>(data, "ApiPath", "Token");
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
