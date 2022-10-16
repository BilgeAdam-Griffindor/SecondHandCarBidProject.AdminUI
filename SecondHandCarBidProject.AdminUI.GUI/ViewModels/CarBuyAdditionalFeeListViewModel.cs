using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyAdditionalFeeListViewModel
    (
        List<CarBuyAdditionalFeeTableRowDTO> TableRows,
        int maxPages
    );
}
