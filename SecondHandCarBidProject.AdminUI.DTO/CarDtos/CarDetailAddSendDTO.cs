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
        List<Guid> SelectedCarProperties,
        List<byte[]> CarImages,
        Guid CreatedBy,
        int? CorporationId
        );
}
