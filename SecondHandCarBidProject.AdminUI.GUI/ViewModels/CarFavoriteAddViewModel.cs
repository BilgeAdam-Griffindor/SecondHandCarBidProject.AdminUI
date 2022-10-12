using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarFavoriteAddViewModel
 (
     Guid CarId,
     Guid BaseUserId,
     List<SelectListItem> CarList,
     List<SelectListItem> BaseUserList
 );
}
