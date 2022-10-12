namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationUserAddViewModels(Guid BaseUserId, int CorporationId, byte IsActive, DateTime CreatedDate, DateTime? ModifiedDate,
       Guid CreatedBy, Guid? ModifiedBy)
    {

    }
}
