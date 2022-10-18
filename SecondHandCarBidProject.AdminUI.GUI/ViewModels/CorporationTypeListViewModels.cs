using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationTypeListViewModels(
        List<CorporationTypeUpdateDTO> TableRows,
        int maxPages);
}
