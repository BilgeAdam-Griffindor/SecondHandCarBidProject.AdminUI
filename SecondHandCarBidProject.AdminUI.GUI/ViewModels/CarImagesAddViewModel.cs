using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarImagesAddViewModel
    (
         List<SelectListItem> CarList,
         string CarImage = "",
         int CarId = 1
    );
}
