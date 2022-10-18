using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationListViewModels(
        List<CorporationUpdateDTO> TableRows,
        int maxPages);
}
