namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{

        public record CorporationUpdateViewModels(
       int Id,
       string CompanyName,
       int AddressInfoId,
       string PhoneNumber,
       int CorporationTypeId,
       Int16 CorporatePackageTypeId,
       bool IsActive,
       DateTime CreatedDate,
       DateTime? ModifiedDate,
       Guid CreatedBy,
       Guid? ModifiedBy
       );
    
}
