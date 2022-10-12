namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageUpdateViewModels(int Id, string Content, byte IsActive, DateTime? ModifiedDate, Guid? ModifiedBy)
    {

    }
}
