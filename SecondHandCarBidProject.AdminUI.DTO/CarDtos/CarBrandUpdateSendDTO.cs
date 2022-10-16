namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBrandUpdateSendDTO(
        short Id,
        string BrandName,
        Guid ModifiedBy
        );
}
