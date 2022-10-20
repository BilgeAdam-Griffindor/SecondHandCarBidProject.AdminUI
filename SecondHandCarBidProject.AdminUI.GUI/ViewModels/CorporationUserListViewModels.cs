using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationUserListViewModels(
        List<CorporationUserUpdateDTO> TableRows,
        int maxPages);
}
