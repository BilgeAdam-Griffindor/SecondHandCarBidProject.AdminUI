using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdvertDtos
{
    public record AdvertInfoListDto(Guid Id,string AdvertTitle,string AdvertDescription,DateTime createdDate,bool IsActive)
    {
    }
}
