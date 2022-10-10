namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarStatusHistoryAddPageDTO(
       List<IdNameListDTO> CarList,
       List<IdNameListDTO> StatusValueList
       );
}
