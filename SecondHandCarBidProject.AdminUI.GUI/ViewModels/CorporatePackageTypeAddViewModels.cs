using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporatePackageTypeAddViewModels(string PackageName, Int16? CountOfBids, bool IsActive,
       List<SelectListItem> CreatedByList)
    { }
}
