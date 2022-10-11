using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationUserUpdateDTO(Guid BaseUserId, int CorporationId, byte IsActive, DateTime CreatedDate, DateTime? ModifiedDate,
       Guid CreatedBy, Guid? ModifiedBy)
    {

    }
}
