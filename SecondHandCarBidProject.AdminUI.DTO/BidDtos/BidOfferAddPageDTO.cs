namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidOfferAddPageDTO(
        List<IdNameListDTO> BaseUserList,
        List<IdNameListDTO> BidList
        );
}
