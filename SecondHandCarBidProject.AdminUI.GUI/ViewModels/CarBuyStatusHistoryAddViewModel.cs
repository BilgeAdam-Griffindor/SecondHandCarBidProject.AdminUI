using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyStatusHistoryAddViewModel
    (
        Guid CarBuyId,
        int StatusValueId,
        string Explanation,
        List<SelectListItem> CarBuyList,
        List<SelectListItem> StatusValueList
    );
}
