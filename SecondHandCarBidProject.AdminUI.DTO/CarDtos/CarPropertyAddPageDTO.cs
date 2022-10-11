namespace SecondHandCarBidProject.AdminUI.DTO.CarDtos
{
    public record CarPropertyAddPageDTO(
        List<IdNameListDTO> CarList,
        List<IdNameListDTO> CarPropertValueList
        );
}
