using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporatePackageTypeListViewModels(
        List<CorporatePackageTypeUpdateDTO> TableRows,
        int maxPages
        );
}
