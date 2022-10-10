namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarImagesTableRowDTO(
       Guid Id,
       string BrandName,
       string ModelName,
       byte[] CarImage
       );
}
