using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarImagesAddViewModel
 (
     Guid CarId,
     byte[] CarImage,
     List<SelectListItem> CarList
 );
}
