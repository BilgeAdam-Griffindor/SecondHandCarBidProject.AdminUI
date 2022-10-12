using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarModelAddViewModel
(
    short CarBrandId,
    string ModelName,
    List<SelectListItem> CarBrandList
);
}
