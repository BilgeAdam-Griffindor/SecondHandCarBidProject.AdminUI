using SecondHandCarBidProject.AdminUI.DTO.AboutUs;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record AboutUsListViewModel(
        List<AboutUsUpdateDTO> TableRows,
        int maxPages);
}
