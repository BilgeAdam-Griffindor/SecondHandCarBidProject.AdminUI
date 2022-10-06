using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class BidStatusHistoryAddViewModel
    {
        public Guid BidId { get; set; }
        public Guid StatusValueId { get; set; }
        public string Explanation { get; set; }
        public List<SelectListItem> StatusValueList { get; set; }
        public List<SelectListItem> BidList { get; set; }
    }
}
