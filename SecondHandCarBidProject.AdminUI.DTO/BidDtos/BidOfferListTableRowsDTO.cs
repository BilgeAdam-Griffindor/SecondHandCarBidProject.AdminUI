namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidOfferListTableRowsDTO(
        Guid Id,
        decimal OfferAmount,
        string BaseUserName,
        string BidName,
        string Explanation
        );
}
