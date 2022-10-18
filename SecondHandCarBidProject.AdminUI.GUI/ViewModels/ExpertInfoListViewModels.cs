using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record ExpertInfoListViewModels(
        List<ExpertInfoUpdateDTO> TableRows,
        int maxPages);
    
    
    
}
