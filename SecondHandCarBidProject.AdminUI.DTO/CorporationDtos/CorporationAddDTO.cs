using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationAddDTO(string CompanyName, int AddressInfoId, string PhoneNumber, int CorporationTypeId,
    Int16 CorporatePackageTypeId, DateTime CreatedDate, Guid CreatedBy)
    {

    }
}
