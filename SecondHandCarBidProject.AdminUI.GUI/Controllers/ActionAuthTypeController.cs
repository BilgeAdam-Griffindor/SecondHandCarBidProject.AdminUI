using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NLog;
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
using LogLevel = NLog.LogLevel;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class ActionAuthTypeController : Controller
    {
        
        ILoggerFactoryMethod<MongoLogModel> logger;
        ILogCatcher cathcLog;
        IBaseDAL service;
        IConfiguration configuration;
        public ActionAuthTypeController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service,IConfiguration _configuration, ILogCatcher _cathcLog)
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
                Exception ex = new Exception();
                await cathcLog.WriteLogWarning(ex);
                //todo When Api will be ready after that update apipath and token parameters
                //var result = await service.ListAll<ActionAuthSelectDTO>("ApiPath", "Token");
            }
            catch (Exception ex)
            {
            
                await cathcLog.WriteLogWarning(ex);
              
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
                await cathcLog.WriteLogWarning(ex);
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
                await cathcLog.WriteLogWarning(ex);
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
                await cathcLog.WriteLogWarning(ex);

            }
           
            return View();
        }
    }
}
