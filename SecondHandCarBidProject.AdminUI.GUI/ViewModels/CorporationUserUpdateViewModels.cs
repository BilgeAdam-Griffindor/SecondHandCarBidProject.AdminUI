namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationUserUpdateViewModels(Guid BaseUserId, int CorporationId, byte IsActive, DateTime CreatedDate, DateTime? ModifiedDate,
       Guid CreatedBy, Guid? ModifiedBy)
    {
      
    }
}
