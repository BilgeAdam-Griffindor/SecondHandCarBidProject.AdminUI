using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record RolePageActionAuthDto(Int16 RoleTypeId,
        Int16 PageAuthTypeId,
        string PageAuthTypeName,
        Int16 ActionAuthTypeId,
        string ActionAuthTypeName,
        bool IsActive,
        DateTime CreatedDate,
        DateTime ModifiedDate,
        Guid CreatedBy,
        Guid ModifiedBy)
    {
        

    }
}
