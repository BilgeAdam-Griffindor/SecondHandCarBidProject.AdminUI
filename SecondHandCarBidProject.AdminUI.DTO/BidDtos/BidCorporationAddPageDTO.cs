namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidCorporationAddPageDTO(
        List<IdNameListDTO> BidList,
        List<IdNameListDTO> CorporationList
        );
}
