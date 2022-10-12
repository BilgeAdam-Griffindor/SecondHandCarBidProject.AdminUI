using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record RoleTypeUpdateDto(Int16 Id, string RoleName, bool IsActive)
    {
    }
}
