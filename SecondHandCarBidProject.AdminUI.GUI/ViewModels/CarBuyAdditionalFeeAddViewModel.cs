using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyAdditionalFeeAddViewModel
    (
        Guid CarBuyId,
        Guid NotaryFeeId,
        Guid CommissionFeeId,
        List<SelectListItem> CarBuyList,
        List<SelectListItem> NotaryFeeList,
        List<SelectListItem> CommissionFeeList
    );
}
