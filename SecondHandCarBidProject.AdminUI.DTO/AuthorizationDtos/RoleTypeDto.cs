using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record RoleTypeDto(Int16 Id,string RoleName,bool IsActive,List<RoleTypeDto> RoleTypeList)
    {
    }
}
