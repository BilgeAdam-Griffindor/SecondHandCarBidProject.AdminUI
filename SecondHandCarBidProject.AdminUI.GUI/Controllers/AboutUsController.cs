using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAboutUs()
        {
            return View();
        }

        public IActionResult AddAboutUs(AboutUsAddViewModel viewData)
        {
            return View();
        }

        public IActionResult UpdateAboutUs()
        {
            return View();
        }

        public IActionResult UpdateAboutUs(AboutUsUpdateViewModel viewData)
        {
            return View();
        }

        public IActionResult RemoveAboutUs(int Id)
        {
            return View();
        }

    }
}
