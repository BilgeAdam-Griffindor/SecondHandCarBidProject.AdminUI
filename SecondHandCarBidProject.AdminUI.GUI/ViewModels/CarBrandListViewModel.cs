using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarBrandListViewModel
    (
        List<CarBrandListTableRow> TableRows,
        int maxPages
    );
}
