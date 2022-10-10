namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarSoldToAddSendDTO(
       Guid CarId,
       Guid SoldToBaseUserId,
       decimal Price
       );
}
