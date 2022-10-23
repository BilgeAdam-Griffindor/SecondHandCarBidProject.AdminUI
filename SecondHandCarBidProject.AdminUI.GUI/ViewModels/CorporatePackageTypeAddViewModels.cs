using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporatePackageTypeAddViewModels(string PackageName, Int16? CountOfBids, byte IsActive,
       List<SelectListItem> CreatedByList)
    { }
}
