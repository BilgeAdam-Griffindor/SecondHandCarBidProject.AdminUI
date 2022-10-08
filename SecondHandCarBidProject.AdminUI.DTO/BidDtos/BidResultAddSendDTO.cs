namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidResultAddSendDTO(
        Guid BidOfferId,
        string Explanation,
        Guid CreatedBy
        );
}
