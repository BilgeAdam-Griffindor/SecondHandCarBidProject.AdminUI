using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationUserAddDTO(
        Guid BaseUserId,
        int CorporationId,
        byte IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy)
    {
        //public BaseUser BaseUser { get; init; }
        //public Corporation Corporation { get; init; }
        //public BaseUser BaseUser { get; init; } 
        //public BaseUser? BaseUser { get; init; } 
    }
}
