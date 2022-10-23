using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageAddViewModels(string Content, byte IsActive, DateTime? ModifiedDate, Guid? ModifiedBy,
        List<SelectListItem> ModifiedByList);
}
