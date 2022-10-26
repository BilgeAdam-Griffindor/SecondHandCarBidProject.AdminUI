using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationUserAddPageDTO(Guid BaseUserId, int CorporationId, DateTime CreatedDate, DateTime? ModifiedDate,
       Guid CreatedBy, Guid? ModifiedBy,
          List<IdNameListDTO> BaseUserList,
        List<IdNameListDTO> CorporationList,
        List<IdNameListDTO> CreatedByList,
        List<IdNameListDTO> ModifiedByList);
}
