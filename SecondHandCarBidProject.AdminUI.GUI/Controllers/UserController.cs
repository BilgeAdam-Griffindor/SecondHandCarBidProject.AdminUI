using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using SecondHandCarBidProject.AdminUI.GUI.Security;
using SecondHandCarBidProject.AdminUI.Validator.ActionAuthType;
using SecondHandCarBidProject.AdminUI.Validator.User;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class UserController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> logger;
        IBaseDAL service;
        public UserController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service)
        {
            logger = _logger;
            service = _service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result = await service.ListAll<ActionAuthSelectDTO>("ApiPath", "Token");
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
        public async Task<IActionResult> UserAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserAdd(BaseUserAddDTO data)
        {
            try
            {
                BaseUserAddValidator validationRules = new BaseUserAddValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<BaseUserAddDTO, Task>(data, "ApiPath", "Token");
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
        public async Task<IActionResult> UserUpdate(Guid id)
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result= await service.GetByFilterAsync<BaseUserUpdateDTO>("ApiPath", "Token",id);

            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning";
                await logger.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, mongoLogModel);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserUpdate(BaseUserUpdateDTO data)
        {
            try
            {
                BaseUserUpdateValidator validationRules = new BaseUserUpdateValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.UpdateAsync<BaseUserUpdateDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel = new MongoLogModel();
                mongoLogModel.CreatedDate = DateTime.Now;
                mongoLogModel.Exception = ex.Message;
                // todo Make enum logtype
                mongoLogModel.LogType = "Warning"; await logger.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, mongoLogModel);
                throw;
            }
            return View();
        }
    }
}
