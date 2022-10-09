using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record RolePageActionAuthAddDto(Int16 PageAuthTypeId,
        Int16 ActionAuthTypeId,
        bool IsActive,
        DateTime CreatedDate,
        DateTime ModifiedDate)
    {
        
    }
}
