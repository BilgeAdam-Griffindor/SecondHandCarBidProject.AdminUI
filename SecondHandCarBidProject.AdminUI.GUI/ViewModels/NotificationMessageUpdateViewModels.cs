namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class NotificationMessageUpdateViewModels
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public byte IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
