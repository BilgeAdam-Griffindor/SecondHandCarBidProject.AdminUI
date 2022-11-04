using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationUpdatePageDTO(int Id,
        string CompanyName,
        int AddressInfoId,
        string PhoneNumber,
        int CorporationTypeId,
        Int16 CorporatePackageTypeId,
        bool IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy,
        List<IdNameListDTO> AddressInfoList, 
        List<IdNameListDTO> CorporationTypeList, 
        List<IdNameListDTO> CorporationPackageTypeList, 
        List<IdNameListDTO> CreatedByList,
        List<IdNameListDTO> ModifiedByList
        );
}
