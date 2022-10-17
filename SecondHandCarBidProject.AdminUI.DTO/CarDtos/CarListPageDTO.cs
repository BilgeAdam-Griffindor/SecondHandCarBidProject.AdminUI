namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarListPageDTO(
        List<IdNameListDTO> BrandList,
        List<IdNameListDTO> ModelList,
        List<IdNameListDTO> StatusList,
        List<CarListTableRowDTO> TableRows,
        int maxPages
        );
}