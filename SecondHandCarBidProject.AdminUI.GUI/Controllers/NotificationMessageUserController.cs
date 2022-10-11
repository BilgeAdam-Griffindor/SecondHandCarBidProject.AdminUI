using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class NotificationMessageUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNotificationMessageUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotificationMessageUser(NotificationMessageUserAddViewModels notificationMessageUserAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateNotificationMessageUser(Guid Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateNotificationMessageUser(NotificationMessageUserUpdateViewModels notificationMessageUserUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveNotificationMessageUser(Guid Id)
        {
            return View();
        }
    }
}
