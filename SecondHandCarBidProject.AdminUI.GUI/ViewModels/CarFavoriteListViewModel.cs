using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record CarFavoriteListViewModel
   (
       List<CarFavoriteTableRowDTO> TableRows
   );
}
