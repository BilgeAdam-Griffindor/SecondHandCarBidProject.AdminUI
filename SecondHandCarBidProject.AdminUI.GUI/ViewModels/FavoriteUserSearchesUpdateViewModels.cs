namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class FavoriteUserSearchesUpdateViewModels
    {
        public Guid Id { get; set; }
        public string SearchText { get; set; }
        public Guid BaseUserId { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
