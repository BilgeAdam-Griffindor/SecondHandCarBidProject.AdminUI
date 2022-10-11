using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarListViewModel
    (
        int? BrandId,
        List<SelectListItem> BrandList,
        int? ModelId,
        List<SelectListItem> ModelList,
        int? StatusId,
        List<SelectListItem> StatusList,
        List<CarListTableRowDTO> TableRows,
        int Page,
        int ItemPerPage
    );
}
