namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidStatusHistoryListPageDTO(
        List<BidStatusHistoryListTableRowsDTO> TableRows,
        int maxPages
        );
}
