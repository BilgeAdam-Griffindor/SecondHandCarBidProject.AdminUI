using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidOfferAddViewModel
    (
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        List<SelectListItem> BaseUserList,
        List<SelectListItem> BidList
    );
}
