using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record BidAdditionalFeeUpdateDTO(Guid Id,DateTime CreatedDate, DateTime ModifiedDate, Guid BidId, Guid NotaryFeeId, Guid CommisionId, bool IsActive)
    {
    }
}
