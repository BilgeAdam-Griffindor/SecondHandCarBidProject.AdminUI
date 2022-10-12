using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdvertDtos
{
    public record AdvertFavoriteSelectDTO(Guid UserId,string UserEmail,string UserName,Guid AdvertId,string AdvertTitle,string AdvertDescription,DateTime CreatedDate,bool IsActive)
    {
    }
}
