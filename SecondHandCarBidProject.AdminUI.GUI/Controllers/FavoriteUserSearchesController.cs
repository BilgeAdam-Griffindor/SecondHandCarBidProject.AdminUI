using Microsoft.AspNetCore.Mvc;
using SecondHandCarBidProject.AdminUI.GUI.ViewModels;

namespace SecondHandCarBidProject.AdminUI.GUI.Controllers
{
    public class FavoriteUserSearchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFavoriteUserSearches()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFavoriteUserSearches(FavoriteUserSearchesAddViewModels favoriteUserSearchesAddViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateFavoriteUserSearches(Guid Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateFavoriteUserSearches(FavoriteUserSearchesUpdateViewModels favoriteUserSearchesUpdateViewModels)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveFavoriteUserSearches(Guid Id)
        {
            return View();
        }
    }
}
