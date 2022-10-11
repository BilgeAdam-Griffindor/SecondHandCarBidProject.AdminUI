namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarFavoriteTableRowDTO(
       string BrandName,
       string ModelName,
       string UserName,
       string UserFirstName,
       string UserLastName,
       DateTime CreatedDate
       );
}
