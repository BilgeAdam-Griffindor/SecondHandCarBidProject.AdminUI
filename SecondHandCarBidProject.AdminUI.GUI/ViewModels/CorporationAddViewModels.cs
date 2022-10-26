using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationAddViewModels
        (string CompanyName,
        int AddressInfoId,
        string PhoneNumber,
        int CorporationTypeId,
        Int16 CorporatePackageTypeId,
        bool IsActive,
        DateTime CreatedDate,
        Guid CreatedBy,
        List<SelectListItem> AdressInfoList,
        List<SelectListItem> CorporationTypeList,
        List<SelectListItem> CorporatePackageTypeList,
        List<SelectListItem> CreatedByList
);
}
