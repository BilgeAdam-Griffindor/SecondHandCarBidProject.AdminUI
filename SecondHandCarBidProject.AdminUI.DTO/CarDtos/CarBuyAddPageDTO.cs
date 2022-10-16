namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyAddPageDTO(
        List<IdNameListDTO> BrandList,
        List<IdNameListDTO> ModelList,
        List<IdNameListDTO> CorporationList,
        List<IdNameListDTO> BodyTypeList,
        List<IdNameListDTO> FuelTypeList,
        List<IdNameListDTO> GearTypeList,
        List<IdNameListDTO> VersionList,
        List<IdNameListDTO> ColorList,
        List<IdNameListDTO> OptionalHardwareList
        );

}
