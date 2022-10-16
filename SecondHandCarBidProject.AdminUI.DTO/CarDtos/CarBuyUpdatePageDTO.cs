namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyUpdatePageDTO(
        Guid Id,
        Guid CarId,
        string UserFullName,
        decimal PreValuationPrice,
        decimal BidPrice,
        int Kilometre,
        short CarYear,
        string CarDescription,
        short CarBrandId,
        int CarModelId,
        int StatusId,
        Guid BodyTypeId,
        Guid FuelTypeId,
        Guid GearTypeId,
        Guid VersionId,
        Guid ColorId,
        List<Guid> OptionalHardwareIds,
        List<CarImageListDTO> CarImages,
        List<IdNameListDTO> StatusList
        );

}
