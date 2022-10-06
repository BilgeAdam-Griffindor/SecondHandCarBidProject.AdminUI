using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos 
{ 
    public record BaseUserSelectDTO(Guid Id, string Name,string Surname,string UserName,string Email,string PhoneNumber,bool IsApproved)
    {
    }
}
