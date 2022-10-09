using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporatePackageTypeUpdateDTO(
        Int16 Id,
        string PackageName,
        Int16? CountOfBids,
        byte IsActive)
    {

    }
}
