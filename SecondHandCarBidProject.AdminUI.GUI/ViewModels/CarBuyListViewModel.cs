using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyListViewModel
    (
        List<SelectListItem> BrandList,
        List<SelectListItem> ModelList,
        List<SelectListItem> StatusList,
        List<CarBuyListTableRowDTO> TableRows,
        int maxPages
    );
}
