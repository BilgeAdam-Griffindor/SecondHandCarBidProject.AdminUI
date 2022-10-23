using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record ExpertInfoAddViewModels(
        string? CentreName,
        int AddressInfoId,
        decimal? Longitude,
        decimal? Latitude,
        byte[]? Picture,
        byte IsActive,
        string? ExpertAddress,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy,
        List<SelectListItem> AddressInfoList,
        List<SelectListItem> CreatedByList,
        List<SelectListItem> ModifiedByList
        );
}
