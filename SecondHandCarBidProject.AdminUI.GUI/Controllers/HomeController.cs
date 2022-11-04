using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Error()
        //{
        //    var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        //    return View();
        //}

        //public IActionResult Hata()
        //{
        //    throw new System.Exception("Sistemsel hata oluştu");
        //}
    }
}
