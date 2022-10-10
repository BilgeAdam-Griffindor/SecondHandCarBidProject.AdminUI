namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarCorporationTableRowDTO(
      string BrandName,
      string ModelName,
      string CompanyName,
      string PhoneNumber,
      DateTime CreatedDate
      );
}
