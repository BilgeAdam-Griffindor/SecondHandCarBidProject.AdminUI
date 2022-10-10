using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidCarDTO(BidSelectDTO bid,List<CarDetailDto> CarsInBid, decimal BidStartPrice,decimal MinumumPrice,
        DateTime CreatedDate,DateTime ModifiedDate,Guid CreatedById, BaseUserSelectDTO baseUser
        )
    {
        //ModifiedBy ?
    }
}
