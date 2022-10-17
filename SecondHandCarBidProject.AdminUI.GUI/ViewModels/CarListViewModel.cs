using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarListViewModel
    (
        List<SelectListItem> BrandList,
        List<SelectListItem> ModelList,
        List<SelectListItem> StatusList,
        List<CarListTableRowDTO> TableRows,
        int maxPages
    );
}
