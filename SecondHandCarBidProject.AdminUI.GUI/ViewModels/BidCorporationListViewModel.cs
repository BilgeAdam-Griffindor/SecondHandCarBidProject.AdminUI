using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidCorporationListViewModel
    (
        List<BidCorporationListTableRowsDTO> TableRows
    );
}
