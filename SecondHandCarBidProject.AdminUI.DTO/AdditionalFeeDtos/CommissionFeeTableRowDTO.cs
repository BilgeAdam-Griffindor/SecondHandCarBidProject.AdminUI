namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record CommissionFeeTableRowDTO(
       Guid Id,
       decimal FeeAmount,
       decimal MinPrice,
       decimal MaxPrice,
       DateTime StartDate,
       DateTime EndDate,
       DateTime CreatedDate
     );
}
