namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidCorporationListTableRowsDTO(
        Guid BidId,
        int CorporationId,
        string BidName,
        string CompanyName
        );
}
