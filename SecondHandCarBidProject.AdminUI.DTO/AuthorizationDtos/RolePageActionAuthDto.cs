using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record RolePageActionAuthDto(Int16 RoleTypeId,
        Int16 PageAuthTypeId,
        Int16 ActionAuthTypeId,
        bool IsActive,
        DateTime CreatedDate,
        DateTime ModifiedDate,
        Guid CreatedBy,
        Guid ModifiedBy,
        List<RolePageActionAuthDto> RolePageActionAuthsList)
    {
        public PageAuthTypeDto PageAuthTypeDto { get; set; }

    }
}
