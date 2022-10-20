using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotaryFeeListViewModels(
        List<NotaryFeeUpdateDTO> TableRows,
        int maxPages);
}
