using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record PageAuthTypeUpdate(Int16 Id,
        string AuthorizationName,
        bool IsActive)
    {
    }
}
