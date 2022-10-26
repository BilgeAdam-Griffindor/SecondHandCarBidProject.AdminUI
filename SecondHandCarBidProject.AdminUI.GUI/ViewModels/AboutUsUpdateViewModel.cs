namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record AboutUsUpdateViewModel(int Id, string HeadLine1, string Content1, string HeadLine2, string Content2, bool IsActive,
        DateTime CreatedDate, DateTime ModifiedDate, Guid CreatedBy, Guid ModifiedBy);
}
