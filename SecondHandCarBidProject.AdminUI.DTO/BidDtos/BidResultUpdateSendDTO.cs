namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidResultUpdateSendDTO(
        Guid Id,
        string Explanation,
        Guid ModifiedBy
        );
}
