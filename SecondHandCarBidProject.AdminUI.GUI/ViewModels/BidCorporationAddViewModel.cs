using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class BidCorporationAddViewModel
    {
        public Guid BidId { get; set; }
        public int CorporationId { get; set; }
        public List<SelectListItem> BidList { get; set; }
        public List<SelectListItem> CorporationList { get; set; }
    }
}
