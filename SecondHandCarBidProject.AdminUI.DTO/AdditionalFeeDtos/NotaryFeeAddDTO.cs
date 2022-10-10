using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record NotaryFeeAddDTO(
        decimal FeeAmount,
        DateTime StartDate,
        DateTime EndDate,
        byte IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy)
    {
        //public BaseUserDTO BaseUser { get; init; } 
        // public BaseUserDTO? BaseUser { get; init; } 
    }
}
