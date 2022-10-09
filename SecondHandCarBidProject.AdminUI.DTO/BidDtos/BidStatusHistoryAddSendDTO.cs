namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidStatusHistoryAddSendDTO(
        Guid BidId,
        Guid StatusValueId,
        string Explanation,
        Guid CreatedBy
        );
}
