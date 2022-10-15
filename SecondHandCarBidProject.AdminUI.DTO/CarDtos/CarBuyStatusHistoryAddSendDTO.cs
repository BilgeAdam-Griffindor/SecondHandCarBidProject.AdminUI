namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyStatusHistoryAddSendDTO(
        Guid CarBuyId,
        int StatusValueId,
        string Explanation,
        Guid CreatedBy
        );
}
