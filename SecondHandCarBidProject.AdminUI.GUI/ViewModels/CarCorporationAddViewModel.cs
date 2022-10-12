using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarCorporationAddViewModel
   (
       Guid CarId,
       Guid CorporationId,
       List<SelectListItem> CarList,
       List<SelectListItem> CorporationList
   );
}
