namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyAdditionalFeeAddPageDTO(
        List<IdNameListDTO> CarBuyList,
        List<IdNameListDTO> NotaryFeeList,
        List<IdNameListDTO> CommissionFeeList
        );
}
