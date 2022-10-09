using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AddressDtos
{
    public record AddressInfoAdd(string AddressName,int TopAddressInfo,int AddressTypeId,bool IsActive)
    {
    }
}
