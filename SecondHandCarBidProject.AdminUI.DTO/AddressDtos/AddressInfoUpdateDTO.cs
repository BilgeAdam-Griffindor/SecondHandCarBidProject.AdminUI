using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AddressDtos
{
    public record AddressInfoUpdateDTO(int Id,string AddressName,int AddressTypeId,bool IsActive,List<OnlyAddressInfoDto> TopAddresses)
    {
    }
}
