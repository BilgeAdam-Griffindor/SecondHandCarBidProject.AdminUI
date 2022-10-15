namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyAddSendDTO(
        int Kilometre,
        short CarYear,
        string CarDescription,
        short CarBrandId,
        int CarModelId,
        List<Guid> SelectedCarProperties,
        List<byte[]> CarImages,
        Guid CreatedBy
        );

}
