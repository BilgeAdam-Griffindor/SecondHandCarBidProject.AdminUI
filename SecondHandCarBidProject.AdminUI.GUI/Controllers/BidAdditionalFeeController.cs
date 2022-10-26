using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DAL.Interfaces;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using SecondHandCarBidProject.AdminUI.Validator.ActionAuthType;
using SecondHandCarBidProject.AdminUI.Validator.AdditionalFee;
using SecondHandCarBidProject.AdminUI.Validator.User;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class BidAdditionalFeeController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> logger;
        ILogCatcher cathcLog;
        IBaseDAL service;
        IConfiguration configuration;
        public BidAdditionalFeeController(ILoggerFactoryMethod<MongoLogModel> _logger, IBaseDAL _service, IConfiguration _configuration, ILogCatcher _cathcLog)
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
                //var result = await service.ListAll<BidAdditionalFeeDTO>("ApiPath", "Token");

            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
                
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BidAdditionalFeeAddDTO data)
        {
            try
            {
                BidadditionalFeeAddValidator validationRules = new BidadditionalFeeAddValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.SaveAsync<BidAdditionalFeeAddDTO, Task>(data, "ApiPath", "Token");
                }

            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                //todo When Api will be ready after that update apipath and token parameters
                //var result= await service.GetByFilterAsync<>("ApiPath", "Token",id);

            }
            catch (Exception ex)
            {
                await cathcLog.WriteLogWarning(ex);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(BidAdditionalFeeUpdateDTO data)
        {
            try
            {
                BidAdditionalUpdateValidator validationRules = new BidAdditionalUpdateValidator();
                ValidationResult result = await validationRules.ValidateAsync(data);
                if (result.IsValid)
                {
                    //todo When Api will be ready after that update apipath and token parameters
                    //await service.UpdateAsync<BidAdditionalFeeUpdateDTO, Task>(data, "ApiPath", "Token");
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
