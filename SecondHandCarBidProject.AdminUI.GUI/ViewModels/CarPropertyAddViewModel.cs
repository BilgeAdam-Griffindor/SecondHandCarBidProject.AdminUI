using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarPropertyAddViewModel
   (
        Guid CarId,
        Guid CarPropertyValueId,
       List<SelectListItem> CarList,
       List<SelectListItem> CarPropertyValueList
   );
}
