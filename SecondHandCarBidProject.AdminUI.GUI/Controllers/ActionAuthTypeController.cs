using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class ActionAuthTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ActionAuthTypeAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ActionAuthTypeAdd(RolePageActionAuthAddDto data)
        {
            return View();
        }
    }
}
