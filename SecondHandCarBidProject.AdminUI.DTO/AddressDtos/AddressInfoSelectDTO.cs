using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AddressDtos
{
    public record AddressInfoSelectDTO(int Id, string AddressName, int TopAddressInfoId, string AddressTypeName, bool IsActive)
    {
    }
}
