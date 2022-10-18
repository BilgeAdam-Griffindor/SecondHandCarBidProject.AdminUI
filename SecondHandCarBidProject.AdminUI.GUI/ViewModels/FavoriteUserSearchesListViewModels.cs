using SecondHandCarBidProject.AdminUI.DTO.UserDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record FavoriteUserSearchesListViewModels(
        List<FavoriteUserSearchesUpdateDTO> TableRows,
        int maxPages);
    

    
}
