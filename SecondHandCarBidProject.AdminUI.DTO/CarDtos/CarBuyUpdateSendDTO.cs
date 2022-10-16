namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyUpdateSendDTO(
        Guid Id,
        int StatusId,
        decimal? PreValuationPrice,
        decimal? BidPrice,
        Guid ModifiedBy
        );

}
