using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record BidCorporationAddViewModel
    (
        Guid BidId,
        int CorporationId,
        List<SelectListItem> BidList,
        List<SelectListItem> CorporationList
    );
}
