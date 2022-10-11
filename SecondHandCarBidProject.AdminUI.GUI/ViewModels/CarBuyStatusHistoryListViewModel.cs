using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBuyStatusHistoryListViewModel
    (
        List<CarBuyStatusHistoryTableRow> TableRows
    );
}
