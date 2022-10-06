using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class BidResultAddViewModel
    {
        public Guid BidOfferId { get; set; }
        public string Explanation { get; set; }
        public List<SelectListItem> BidOfferList { get; set; }
    }
}
