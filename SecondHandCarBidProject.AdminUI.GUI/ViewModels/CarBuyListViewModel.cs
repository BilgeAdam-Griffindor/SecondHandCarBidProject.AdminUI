using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class CarBuyListViewModel
    {
        public int? BrandId { get; set; }
        public List<SelectListItem> BrandList { get; set; }

        public int? ModelId { get; set; }
        public List<SelectListItem> ModelList { get; set; }

        public int? StatusId { get; set; }
        public List<SelectListItem> StatusList { get; set; }

        public List<CarBuyListTableRowDTO> TableRows { get; set; }

        public int Page { get; set; }
        public int ItemPerPage { get; set; }
    }
}
