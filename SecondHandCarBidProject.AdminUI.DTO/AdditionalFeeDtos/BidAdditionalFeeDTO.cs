using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record BidAdditionalFeeDTO(Guid Id,DateTime CreatedDate,DateTime ModifiedDate,BidSelectDTO bid,NotaryFeeAddDTO notaryFee, CommissionFeeListPageDTO commision, bool IsActive)
    {
    }
}
