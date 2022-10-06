namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidOfferUpdatePageDTO(
        Guid Id,
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation,
        Guid CreatedBy,
        List<IdNameListDTO> BaseUserList,
        List<IdNameListDTO> BidList
        );
}
