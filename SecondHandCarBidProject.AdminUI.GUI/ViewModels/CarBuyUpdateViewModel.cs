using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyUpdateViewModel
    (
        Guid Id,
        Guid CarId,
        string UserFullName,
        decimal? PreValuationPrice,
        decimal? BidPrice,
        int Kilometre,
        short CarYear,
        string CarDescription,
        short CarBrandId,
        int CarModelId,
        int StatusId,
        Guid BodyTypeId,
        Guid FuelTypeId,
        Guid GearTypeId,
        Guid VersionId,
        Guid ColorId,
        List<Guid> OptionalHardwareIds,
        List<IFormFile> CarImages,
        List<SelectListItem> BrandList,
        List<SelectListItem> ModelList,
        List<SelectListItem> StatusList,
        List<SelectListItem> BodyTypeList,
        List<SelectListItem> FuelTypeList,
        List<SelectListItem> GearTypeList,
        List<SelectListItem> VersionList,
        List<SelectListItem> ColorList,
        List<SelectListItem> OptionalHardwareList
    );
}
