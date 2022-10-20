using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageListViewModels(
        List<NotificationMessageUpdateDTO> TableRows,
        int maxPages);
}
