using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidStatusHistoryListViewModel
    (
        List<BidStatusHistoryListTableRowsDTO> TableRows,
        int maxPages
    );
}
