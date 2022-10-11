namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class NotificationMessageAddViewModels
    {
        public string Content { get; set; }
        public byte IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
