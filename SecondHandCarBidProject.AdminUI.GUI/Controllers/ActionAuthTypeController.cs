using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SecondHandCarBidProject.AdminUI.Validator.ActionAuthType;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;
using System;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class ActionAuthTypeController : Controller
    {
        
        ILoggerFactoryMethod<MongoLogModel> logger;
        IBaseDAL service;
        public ActionAuthTypeController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service)
        {
            logger=_logger;
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
        public async Task<IActionResult> ActionAuthTypeAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActionAuthTypeAdd(ActionAuthTypeAddDTO data)
        {
            try
            {
                ActionAuthTypeAddValidator validationRules = new ActionAuthTypeAddValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<ActionAuthTypeAddDTO, Task>(data, "ApiPath", "Token");
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
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ActionAuthTypeUpdate(string id)
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result= await service.GetByFilterAsync<ActionAuthTypeAddDTO>("ApiPath", "Token",id);

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
        public async Task<IActionResult> ActionAuthTypeUpdate(ActionAuthTypeUpdateDTO data)
        {
            try
            {
                ActionAuthTypeUpdateValidator validationRules = new ActionAuthTypeUpdateValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.UpdateAsync<ActionAuthTypeUpdateDTO, Task>(data, "ApiPath", "Token");
                }
            }
            catch (Exception ex)
            {
                MongoLogModel mongoLogModel= new MongoLogModel();
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
