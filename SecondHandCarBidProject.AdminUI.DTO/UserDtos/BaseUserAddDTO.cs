using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos
{
    public record BaseUserAddDTO(string FirstName,string SurName,string UserName,string Password,string Email,bool IsApproved)
    {
    }
}
