using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationUserAddDTO(Guid BaseUserId, int CorporationId, DateTime CreatedDate, DateTime? ModifiedDate,
       Guid CreatedBy, Guid? ModifiedBy)
    {

    }
}
