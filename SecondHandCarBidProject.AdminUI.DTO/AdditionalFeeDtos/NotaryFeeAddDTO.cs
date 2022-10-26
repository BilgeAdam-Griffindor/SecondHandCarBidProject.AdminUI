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
        DateTime CreatedDate,
        Guid CreatedBy
        )
    {
        //public BaseUserDTO BaseUser { get; init; } 
        // public BaseUserDTO? BaseUser { get; init; } 
    }
}
