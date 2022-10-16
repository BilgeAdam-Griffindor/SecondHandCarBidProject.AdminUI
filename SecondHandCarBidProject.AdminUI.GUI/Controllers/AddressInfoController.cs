using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Logging;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AddressInfoController : Controller
    {
        ILoggerFactoryMethod<MongoLogModel> log;
        public AddressInfoController(ILoggerFactoryMethod<MongoLogModel> _log)
        {
            log = _log;
        }
        public IActionResult Index()
        {
            MongoLogModel mongoLogModel = new MongoLogModel();
            return View();
        }
        [HttpGet]
        
        public IActionResult AddressInfoAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddressInfoAdd(AddressInfoAdd data)
        {
            return View();
        }

        [HttpGet] 
        public IActionResult UpdateAddressInfo(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAddressInfo(AddressInfoAdd data)
        {
            return View();
        }
    }
}
