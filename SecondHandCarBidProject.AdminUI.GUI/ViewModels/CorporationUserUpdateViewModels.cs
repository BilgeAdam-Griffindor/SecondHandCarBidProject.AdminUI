namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationUserUpdateViewModels
        (Guid BaseUserId,
        int CorporationId,
        bool IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy);

}
