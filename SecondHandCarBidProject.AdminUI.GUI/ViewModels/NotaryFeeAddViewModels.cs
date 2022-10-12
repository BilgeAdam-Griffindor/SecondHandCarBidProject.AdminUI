namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotaryFeeAddViewModels(decimal FeeAmount, DateTime StartDate, DateTime EndDate, byte IsActive, DateTime CreatedDate,
        DateTime? ModifiedDate, Guid CreatedBy, Guid? ModifiedBy)
    {

    }
}
