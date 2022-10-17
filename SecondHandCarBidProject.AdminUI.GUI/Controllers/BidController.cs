using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
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
        IBaseServices service;
        public BidController(ILoggerFactoryMethod<MongoLogModel> _log, IBaseServices _service)
        {
            logger = _log;
            service = _service;
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
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                await logger.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, mongoLogModel);
                throw;
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
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                await logger.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, mongoLogModel);
                throw;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BidUpdate(Guid id)
        {
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
                   // await service.SaveAsync<BidUpdateDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                await logger.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, mongoLogModel);
                throw;
            }
            return View();
        }
    }
}
