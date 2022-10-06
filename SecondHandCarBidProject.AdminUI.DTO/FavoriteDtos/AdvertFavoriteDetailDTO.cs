using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.FavoriteDtos
{
    public record AdvertFavoriteDetailDTO(Guid BaseUserID,string UserName,List<AdvertListDto> AdverLists)
    {
    }
}
