namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyListTableRowDTO(
        Guid Id,
        Guid CarId,
        string BrandName,
        string ModelName,
        string Status,
        string OwnerUser,
        DateTime CreatedDate
        );

}
