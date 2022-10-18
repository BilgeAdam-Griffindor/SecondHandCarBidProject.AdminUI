namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationAddViewModels
        (string CompanyName,
        int AddressInfoId,
        string PhoneNumber,
        int CorporationTypeId,
        Int16 CorporatePackageTypeId,
        byte IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy)
    {
    }
}
