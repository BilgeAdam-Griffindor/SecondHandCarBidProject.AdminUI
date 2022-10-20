namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
        public record NotaryFeeUpdateViewModels(
       Guid Id,
       decimal FeeAmount,
       DateTime StartDate,
       DateTime EndDate,
       bool IsActive,
       DateTime CreatedDate,
       DateTime? ModifiedDate,
       Guid CreatedBy,
       Guid? ModifiedBy);
}
