namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarFavoriteAddSendDTO(
       Guid CarId,
       Guid BaseUserId,
       Guid CreatedBy
       );
}
