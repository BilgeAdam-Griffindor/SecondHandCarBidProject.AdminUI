namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyAdditionalFeeListPageDTO(
        List<CarBuyAdditionalFeeTableRowDTO> TableRows,
        int maxPages
        );
}
