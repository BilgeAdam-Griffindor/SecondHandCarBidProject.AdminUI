using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class CarBuyHistoryAddViewModel
    {
        public Guid CarBuyId { get; set; }
        public int StatusValueId { get; set; }
        public string Explanation { get; set; }
        public List<SelectListItem> CarBuyList { get; set; }
        public List<SelectListItem> StatusValueList { get; set; }
    }
}
