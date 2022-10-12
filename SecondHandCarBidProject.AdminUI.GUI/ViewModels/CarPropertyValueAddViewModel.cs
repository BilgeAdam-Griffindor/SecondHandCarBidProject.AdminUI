using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarPropertyValueAddViewModel
(
    string PropertyValue,
    Guid TopPropertyValueId,
    List<SelectListItem> TopPropertValueList
);
}
