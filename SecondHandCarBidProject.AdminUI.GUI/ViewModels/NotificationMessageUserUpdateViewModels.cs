namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class NotificationMessageUserUpdateViewModels
    {
        public Guid Id { get; set; }
        public int NotificationMessageId { get; set; }
        public Guid SendToBaseUserId { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
