namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyStatusHistoryAddPageDTO(
        List<IdNameListDTO> CarBuyList,
        List<IdNameListDTO> StatusValueList
        );
}
