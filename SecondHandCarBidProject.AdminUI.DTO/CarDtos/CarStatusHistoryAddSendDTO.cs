namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarStatusHistoryAddSendDTO(
       Guid CarId,
       int StatusValueId,
       string Explanation
       );
}
