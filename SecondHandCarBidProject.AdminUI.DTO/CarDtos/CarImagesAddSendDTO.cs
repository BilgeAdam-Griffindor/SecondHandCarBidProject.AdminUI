namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarImagesAddSendDTO(
       Guid CarId,
       byte[] CarImage
       );
}
