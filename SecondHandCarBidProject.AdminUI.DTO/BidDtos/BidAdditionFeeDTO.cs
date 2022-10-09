using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidAdditionFeeDTO(Guid Id,BidSelectDTO bidInfo,bool IsActive,DateTime CreatedDate,DateTime LasModifiedDate,
        Guid CreatedById,string CreatedByName)
    {
        //BiddNotaryFee Eklenir
        //BiddCommisionFee Eklenir
    }
}
