using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidAddDTO(string BidName,bool IsCorporate,DateTime BidStartDate,DateTime BidEndDate,bool IsActive,DateTime CreatedTime, Guid CreatedBy)
    {
       
    }
}
