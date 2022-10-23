using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CorporationUserAddViewModels
        (Guid BaseUserId,
        int CorporationId,
        byte IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
       Guid CreatedBy,
       Guid? ModifiedBy,
       List<SelectListItem> BaseUserList,
       List<SelectListItem> CorporationList,
       List<SelectListItem> CreatedByList,
       List<SelectListItem> ModifiedByList);
}
