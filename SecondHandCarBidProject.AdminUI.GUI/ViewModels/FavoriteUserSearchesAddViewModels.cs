using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record FavoriteUserSearchesAddViewModels(string SearchText, Guid BaseUserId, bool IsActive, DateTime CreatedDate, List<SelectListItem> BaseUserList)
    {
    }
}
