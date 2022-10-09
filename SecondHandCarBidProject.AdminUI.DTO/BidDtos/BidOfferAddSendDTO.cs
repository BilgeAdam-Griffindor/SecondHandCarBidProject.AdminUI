namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidOfferAddSendDTO(
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        Guid CreatedBy
        );
}
