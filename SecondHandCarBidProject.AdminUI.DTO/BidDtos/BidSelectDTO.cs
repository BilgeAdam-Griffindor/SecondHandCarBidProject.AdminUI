using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidSelectDTO(Guid Id,string BidName,bool IsCorporate,DateTime StartDate,DateTime EndDate,bool IsApproved
        ,List<BidAdditionFeeDTO> bidadditionalFee)
    {
        
    }
}
