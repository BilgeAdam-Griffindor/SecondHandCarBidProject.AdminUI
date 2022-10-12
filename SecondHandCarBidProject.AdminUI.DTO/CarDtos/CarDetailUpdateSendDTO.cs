namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarDetailUpdateSendDTO(
        Guid Id,
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
        int? CorporationId,
        Guid ModifiedBy
        );
}
