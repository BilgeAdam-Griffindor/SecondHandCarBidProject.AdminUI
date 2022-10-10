namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarStatusHistoryTableRowDTO(
       Guid Id,
       string BrandName,
       string ModelName,
       string Status,
       string Explanation,
       DateTime CreatedDate
       );
}
