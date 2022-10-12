namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CommissionFeeAddViewModel
(
      decimal FeeAmount,
       decimal MinPrice,
       decimal MaxPrice,
       DateTime StartDate,
       DateTime EndDate
);
}
