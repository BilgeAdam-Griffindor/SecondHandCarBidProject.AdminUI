namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageUserAddViewModels(int NotificationMessageId, Guid SendToBaseUserId, byte IsActive, DateTime CreatedDate,
        Guid CreatedBy)
    {
 
    }
}
