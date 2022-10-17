using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos
{
    public record BaseUserUpdateDTO(Guid Id,string FirstName,string SurName,string Password,
        string PhoneNumber,int AddressInfoId,List<AddressInfoSelectDTO> AddressForBaseUser,List<AddressInfoSelectDTO> ForUpdateAddressList,bool Approved,bool IsActive,DateTime ModifiedDate, Guid ApprovedBy,bool KvkkChecked,
        Guid RoleTypeId,bool IsCorporate)
    {
        // Role tipi geldiğinde Dto eklenir. List<RoleTypesDtO>
    }
} 
