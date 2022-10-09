using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarBrandListPageDTO(
        List<IdNameListDTO> CarBrands
        );
}
