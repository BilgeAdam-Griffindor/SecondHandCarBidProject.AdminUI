using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationUserAddViewModels
        (Guid BaseUserId,
        int CorporationId,
        bool IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
       Guid CreatedBy,
       Guid? ModifiedBy,
       List<SelectListItem> BaseUserList,
       List<SelectListItem> CorporationList,
       List<SelectListItem> CreatedByList,
       List<SelectListItem> ModifiedByList);
}
