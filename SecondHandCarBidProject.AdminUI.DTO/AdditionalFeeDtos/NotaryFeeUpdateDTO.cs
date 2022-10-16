using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record NotaryFeeUpdateDTO(
        Guid Id,
        decimal FeeAmount,
        DateTime StartDate,
        DateTime EndDate,
        bool IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy)
    {
        //public BaseUserDTO BaseUser { get; init; } 
        // public BaseUserDTO? BaseUser { get; init; } 
    }
}
