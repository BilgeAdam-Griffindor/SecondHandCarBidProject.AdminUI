namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBuyAdditionalFeeAddSendDTO(
        Guid CarBuyId,
        Guid NotaryFeeId,
        Guid CommissionFeeId,
        Guid CreatedBy
        );
}
