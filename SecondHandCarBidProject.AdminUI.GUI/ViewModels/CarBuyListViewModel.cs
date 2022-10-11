using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyListViewModel
    (
        int? BrandId,
        List<SelectListItem> BrandList,
        int? ModelId,
        List<SelectListItem> ModelList,
        int? StatusId,
        List<SelectListItem> StatusList,
        List<CarBuyListTableRowDTO> TableRows,
        int Page,
        int ItemPerPage
    );
}
