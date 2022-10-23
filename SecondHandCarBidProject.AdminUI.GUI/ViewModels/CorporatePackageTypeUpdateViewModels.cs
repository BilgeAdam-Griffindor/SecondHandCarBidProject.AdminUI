using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{

        public record CorporatePackageTypeUpdateViewModels
    (Int16 Id,
    string PackageName,
    Int16? CountOfBids,
    bool IsActive,
     List<SelectListItem> CreatedByList
/*     Guid CreatedBy*/);
}

