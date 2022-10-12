using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarCorporationListViewModel
    (
        List<CarCorporationTableRowDTO> TableRows
    );
}
