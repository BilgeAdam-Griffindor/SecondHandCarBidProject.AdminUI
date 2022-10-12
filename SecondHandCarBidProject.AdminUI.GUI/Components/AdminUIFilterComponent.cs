using Microsoft.AspNetCore.Mvc;

namespace SecondHandCarBidProject.AdminUI.GUI.Components
{
    public class AdminUIFilterComponent:ViewComponent
    {
        public AdminUIFilterComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
