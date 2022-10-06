namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyStatusHistoryListPageDTO(
        Guid Id,
        Guid CarBuyId,
        //TODO might be necessary to get extra CarBuy columns
        string StatusName,
        string Explanation
        );
}
