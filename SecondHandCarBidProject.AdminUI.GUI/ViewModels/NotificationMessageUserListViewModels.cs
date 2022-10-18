using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels
{
    public record NotificationMessageUserListViewModels(
        List<NotificationMessageUserUpdateDTO> TableRows,
        int maxPages);
}
