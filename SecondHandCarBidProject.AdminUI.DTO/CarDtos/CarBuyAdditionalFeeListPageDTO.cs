namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyAdditionalFeeListPageDTO(
        Guid Id,
        Guid CarBuyId,
        Guid CarId,
        string BrandName,
        string ModelName,
        decimal PreValuationPrice,
        decimal BidPrice,
        string CarOwnerUser,
        DateTime CarBuyCreatedDate

        //TODO Notary info Guid NotaryFeeId,
        //TODO Commission ino Guid CommisionFeeId
        );
}
