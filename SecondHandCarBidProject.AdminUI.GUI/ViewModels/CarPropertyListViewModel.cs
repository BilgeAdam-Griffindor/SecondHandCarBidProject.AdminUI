using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarPropertyListViewModel
    (
        List<CarPropertyTableRowDTO> TableRows
    );
}
