using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarSoldToAddViewModel
(
       Guid CarId,
       Guid SoldToBaseUserId,
       decimal Price,
       List<SelectListItem> CarList,
       List<SelectListItem> BaseUserList
);
}
