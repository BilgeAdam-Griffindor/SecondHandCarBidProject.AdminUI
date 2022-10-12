namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageUserUpdateViewModels(Guid Id, int NotificationMessageId, Guid SendToBaseUserId, byte IsActive, DateTime CreatedDate,
        Guid CreatedBy)
    {

    }
}
