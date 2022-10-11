namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarSoldToAddPageDTO(
       List<IdNameListDTO> CarList,
       List<IdNameListDTO> BaseUserList
       );
}
