using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdvertDtos
{
    public record AdvertAddDTO(string AdvertTitle,string AdvertDescription,bool IActive,DateTime CreatedDate,DateTime ModifiedDate, CarDetailAddSendDTO car)
    {
    }
}
