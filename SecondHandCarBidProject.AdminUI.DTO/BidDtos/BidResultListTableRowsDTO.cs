namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidResultListTableRowsDTO(
        Guid Id,
        string BidName,
        decimal OfferAmount,
        string OfferExplanation,
        string OfferOwnerName,
        string ResultExplanation
        );
}
