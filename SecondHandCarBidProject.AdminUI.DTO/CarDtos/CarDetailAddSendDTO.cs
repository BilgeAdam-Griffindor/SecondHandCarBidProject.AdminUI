namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarDetailAddSendDTO(
        decimal Price,
        int Kilometre,
        short CarYear,
        bool IsCorporate,
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
        List<byte[]> CarImages,
        Guid CreatedBy,
        int? CorporationId
        );
}
