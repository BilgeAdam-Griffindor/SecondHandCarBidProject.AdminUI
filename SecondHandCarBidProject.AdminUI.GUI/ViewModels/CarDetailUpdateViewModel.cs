using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarDetailUpdateViewModel
    (
        Guid Id,
        decimal Price,
        int Kilometre,
        short CarYear,
        bool IsCorporate,
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
        List<CarImageListDTO> CarImages,
        List<SelectListItem> BrandList,
        List<SelectListItem> ModelList,
        List<SelectListItem> StatusList,
        List<SelectListItem> CorporationList,
        List<SelectListItem> BodyTypeList,
        List<SelectListItem> FuelTypeList,
        List<SelectListItem> GearTypeList,
        List<SelectListItem> VersionList,
        List<SelectListItem> ColorList,
        List<SelectListItem> OptionalHardwareList
    );
}
