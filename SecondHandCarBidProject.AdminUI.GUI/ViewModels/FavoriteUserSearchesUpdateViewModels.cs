using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
        public record FavoriteUserSearchesUpdateViewModels(
      Guid Id,
      string SearchText,
      Guid BaseUserId,
      bool IsActive,
      DateTime CreatedDate,
      List<SelectListItem> BaseUserList
      );
}
