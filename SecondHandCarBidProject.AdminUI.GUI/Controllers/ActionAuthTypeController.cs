using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class ActionAuthTypeController : Controller
    {
        ILoggerFactoryMethod logger;
        public ActionAuthTypeController(ILoggerFactoryMethod _logger)
        {
            logger=_logger; 
        }
        public IActionResult Index()
        {
            //Log Deneme
            //LogModel logModel = new LogModel();
            //logModel.Exception = "asdasdasd";
            //logModel.CreatedDate = DateTime.Now;
            //logModel.LogType = "NullExpection";
            //logger.FactoryMethod(LoggerFactoryMethod.LoggerType.MongoDatabaseLogger,logModel);
            return View();
        }
        [HttpGet]
        public IActionResult ActionAuthTypeAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActionAuthTypeAdd(RolePageActionAuthAddDto data)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActionAuthTypeUpdate(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActionAuthTypeUpdate(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
