namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidOfferUpdateSendDTO(
        Guid Id,
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        Guid ModifiedBy
        );
}
