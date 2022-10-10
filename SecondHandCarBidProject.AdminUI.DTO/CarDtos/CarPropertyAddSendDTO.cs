namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarPropertyAddSendDTO(
        Guid CarId,
        Guid CarPropertyValueId,
        Guid CreatedBy
        );
}
