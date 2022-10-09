using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidAddDto(string BidName,bool IsCorporate,int CorporationID,short StatusId,DateTime BidStartDate
        ,DateTime BidEndDate)
    {
        //List<CarDto> eklenecek
    }
}
