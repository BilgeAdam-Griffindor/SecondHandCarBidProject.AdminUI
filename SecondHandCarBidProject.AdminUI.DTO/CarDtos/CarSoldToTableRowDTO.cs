namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarSoldToTableRowDTO(
        Guid Id,
        string BrandName,
        string ModelName,
        string UserName,
        string UserFirstName,
        string UserLastName,
        decimal Price,
        DateTime CreatedDate
      );
}
