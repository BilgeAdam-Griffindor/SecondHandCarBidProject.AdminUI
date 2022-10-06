namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidStatusHistoryListTableRowsDTO(
        Guid Id,
        string BidName,
        string StatusName,
        string Explanation
        );
}
