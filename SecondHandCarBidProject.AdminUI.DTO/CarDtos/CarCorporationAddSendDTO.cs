namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarCorporationAddSendDTO(
        Guid CarId,
        Guid CorporationId,
        Guid CreatedBy
        );
}
