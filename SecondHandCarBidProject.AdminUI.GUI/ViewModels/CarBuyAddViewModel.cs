using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyAddViewModel
    (
        int Kilometre,
        short CarYear,
        string CarDescription,
        short CarBrandId,
        int CarModelId,
        Guid BodyTypeId,
        Guid FuelTypeId,
        Guid GearTypeId,
        Guid VersionId,
        Guid ColorId,
        List<Guid> OptionalHardwareIds, //TODO may need to adjust
        string CarImages, //TODO correct?
        List<SelectListItem> BrandList,
        List<SelectListItem> ModelList,
        List<SelectListItem> BodyTypeList,
        List<SelectListItem> FuelTypeList,
        List<SelectListItem> GearTypeList,
        List<SelectListItem> VersionList,
        List<SelectListItem> ColorList,
        List<SelectListItem> OptionalHardwareList
    );
}
