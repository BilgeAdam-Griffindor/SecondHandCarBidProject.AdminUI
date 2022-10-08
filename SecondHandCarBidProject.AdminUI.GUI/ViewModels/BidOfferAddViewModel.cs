using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class BidOfferAddViewModel
    {
        public decimal OfferAmount { get; set; }
        public Guid BaseUserId { get; set; }
        public Guid BidId { get; set; }
        public string Explanation { get; set; }
        public List<SelectListItem> BaseUserList { get; set; }
        public List<SelectListItem> BidList { get; set; }
    }
}
