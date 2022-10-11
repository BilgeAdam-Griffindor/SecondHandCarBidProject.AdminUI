using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidResultAddViewModel
    (
        Guid BidOfferId,
        string Explanation,
        List<SelectListItem> BidOfferList
    );
}
