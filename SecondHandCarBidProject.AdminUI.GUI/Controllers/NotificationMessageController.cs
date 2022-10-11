using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class NotificationMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNotificationMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotificationMessage(NotificationMessageAddViewModels notificationMessageAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateNotificationMessage(int Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateNotificationMessage(NotificationMessageUpdateViewModels notificationMessageUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveNotificationMessage(int Id)
        {
            return View();
        }
    }
}
