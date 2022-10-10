namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidCorporationAddSendDTO(
        Guid BidId,
        int CorporationId,
        Guid CreatedBy
        );
}
