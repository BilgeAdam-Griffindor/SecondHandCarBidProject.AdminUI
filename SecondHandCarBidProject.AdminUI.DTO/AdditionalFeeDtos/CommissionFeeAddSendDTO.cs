namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record CommissionFeeAddSendDTO(
       decimal FeeAmount,
       decimal MinPrice,
       decimal MaxPrice,
       DateTime StartDate,
       DateTime EndDate
       );
}
