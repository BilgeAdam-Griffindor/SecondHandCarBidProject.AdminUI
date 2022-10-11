using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidOfferUpdateViewModel
    (
        Guid Id,
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        List<SelectListItem> BaseUserList,
        List<SelectListItem> BidList
    );
}
