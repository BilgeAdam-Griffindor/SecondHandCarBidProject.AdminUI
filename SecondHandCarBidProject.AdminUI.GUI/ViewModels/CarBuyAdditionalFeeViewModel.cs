using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class CarBuyAdditionalFeeViewModel
    {
        public Guid CarBuyId { get; set; }
        public Guid NotaryFeeId { get; set; }
        public Guid CommissionFeeId { get; set; }
        public Guid CreatedBy { get; set; }
        public List<SelectListItem> CarBuyList { get; set; }
        public List<SelectListItem> NotaryFeeList { get; set; }
        public List<SelectListItem> CommissionFeeList { get; set; }
    }
}
