namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidStatusHistoryAddPageDTO(
        List<IdNameListDTO> BidList,
        List<IdNameListDTO> StatusValueList
        );
}
