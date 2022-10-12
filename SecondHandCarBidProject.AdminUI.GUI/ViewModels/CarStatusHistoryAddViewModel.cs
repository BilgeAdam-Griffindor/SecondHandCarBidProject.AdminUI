using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarStatusHistoryAddViewModel
(
       Guid CarId,
       int StatusValueId,
       string Explanation,
       List<SelectListItem> CarList,
       List<SelectListItem> StatusValueList
);
}
