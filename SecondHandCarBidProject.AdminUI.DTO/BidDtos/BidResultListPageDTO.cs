namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidResultListPageDTO(
        List<BidResultListTableRowsDTO> TableRows,
        int maxPages
        );
}
