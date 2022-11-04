using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationAddPageDTO(string CompanyName, int AddressInfoId, string PhoneNumber, int CorporationTypeId,
    Int16 CorporatePackageTypeId, DateTime CreatedDate, Guid CreatedBy, DateTime ModifiedDate, Guid ModifiedBy,
        List<IdNameListDTO> AddressInfoList,
        List<IdNameListDTO> CorporationTypeList, 
        List<IdNameListDTO> CorporatePackageTypeList, 
        List<IdNameListDTO> CreatedByList, 
        List<IdNameListDTO> ModifiedByList

        );
}
