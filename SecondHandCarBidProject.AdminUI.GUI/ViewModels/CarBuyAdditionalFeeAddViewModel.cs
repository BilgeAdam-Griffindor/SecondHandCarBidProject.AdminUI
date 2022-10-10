using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class CarBuyAdditionalFeeAddViewModel
    {
        public Guid CarBuyId { get; set; }
        public Guid NotaryFeeId { get; set; }
        public Guid CommissionFeeId { get; set; }
        public List<SelectListItem> CarBuyList { get; set; }
        public List<SelectListItem> NotaryFeeList { get; set; }
        public List<SelectListItem> CommissionFeeList { get; set; }
    }
}
