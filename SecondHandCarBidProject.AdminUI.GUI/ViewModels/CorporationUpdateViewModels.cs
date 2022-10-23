using Microsoft.AspNetCore.Mvc.Rendering;

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
       Guid? ModifiedBy,
       List<SelectListItem> AdressInfoList,
       List<SelectListItem> CorporationTypeList,
       List<SelectListItem> CorporatePackageTypeList,
       List<SelectListItem> CreatedByList,
       List<SelectListItem> ModifiedByList);
    
}
