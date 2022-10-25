using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageUserAddViewModels(int NotificationMessageId, Guid SendToBaseUserId, bool IsActive, DateTime CreatedDate,
        Guid CreatedBy, List<SelectListItem> CreatedByList, List<SelectListItem> NotificationMessageList,
     List<SelectListItem> SendToBaseUserList
);
}
