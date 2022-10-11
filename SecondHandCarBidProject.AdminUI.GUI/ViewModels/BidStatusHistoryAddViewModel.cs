using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidStatusHistoryAddViewModel
    (
        Guid BidId,
        Guid StatusValueId,
        string Explanation,
        List<SelectListItem> StatusValueList,
        List<SelectListItem> BidList
    );
}
