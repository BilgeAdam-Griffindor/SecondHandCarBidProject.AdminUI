using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public class CarDetailUpdateViewModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Kilometre { get; set; }
        public short CarYear { get; set; }
        public bool IsCorporate { get; set; }
        public string CarDescription { get; set; }
        public short CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public int StatusId { get; set; }
        public Guid BodyTypeId { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid GearTypeId { get; set; }
        public Guid VersionId { get; set; }
        public Guid ColorId { get; set; }
        public List<Guid> OptionalHardwareIds { get; set; }
        public List<CarImageListDTO> CarImages { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public List<SelectListItem> ModelList { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> CorporationList { get; set; }
        public List<SelectListItem> BodyTypeList { get; set; }
        public List<SelectListItem> FuelTypeList { get; set; }
        public List<SelectListItem> GearTypeList { get; set; }
        public List<SelectListItem> VersionList { get; set; }
        public List<SelectListItem> ColorList { get; set; }
        public List<SelectListItem> OptionalHardwareList { get; set; }
        //TODO Tramer info and in other car classes
    }
}
