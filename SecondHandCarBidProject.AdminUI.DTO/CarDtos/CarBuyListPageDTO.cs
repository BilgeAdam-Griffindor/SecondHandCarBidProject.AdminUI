namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyListPageDTO(
        List<IdNameListDTO> BrandList,
        List<IdNameListDTO> ModelList,
        List<IdNameListDTO> StatusList,
        List<CarBuyListTableRowDTO> TableRows,
        int maxPages
        );

}
