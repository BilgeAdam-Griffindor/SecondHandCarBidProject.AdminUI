using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels.PageAuthType
{
    public record PageAuthTypeListDTO
        (
        List<PageAuthTypeDto> pageAuthTypeDtos,
        int maxPages
        )
    {
        
    }
}
