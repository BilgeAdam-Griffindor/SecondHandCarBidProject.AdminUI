using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidOfferListViewModel
    (
        List<BidOfferListTableRowsDTO> TableRows,
        int maxPages
    );
}
