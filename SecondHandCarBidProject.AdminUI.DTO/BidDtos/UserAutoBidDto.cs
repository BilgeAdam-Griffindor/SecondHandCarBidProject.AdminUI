using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record UserAutoBidDto(Guid Id,decimal MaximumOffer,decimal IncrementAmount,Guid BaseUserId,Guid BidId,bool IsActive,DateTime CreatedDate, DateTime ModifiedDate, Guid CreatedBy, Guid ModifiedBy,List<UserAutoBidDto> UserAutoBidList)
    {
    }
}
