using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
        public record NotificationMessageUpdateViewModels(
       int Id,
       string Content,
       bool IsActive,
       DateTime? ModifiedDate,
       Guid? ModifiedBy,
       List<SelectListItem> ModifiedByList
   );
    
}
