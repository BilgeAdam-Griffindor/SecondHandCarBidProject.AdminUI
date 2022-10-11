namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarFavoriteAddPageDTO(
      List<IdNameListDTO> CarList,
      List<IdNameListDTO> BaseUserList
      );
}
