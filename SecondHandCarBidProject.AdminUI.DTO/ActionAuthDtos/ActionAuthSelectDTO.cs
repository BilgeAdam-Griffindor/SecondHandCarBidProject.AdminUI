using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos
{
    public record ActionAuthSelectDTO(short Id,string AuthorizationName,bool IsActive)
    {
    }
}
