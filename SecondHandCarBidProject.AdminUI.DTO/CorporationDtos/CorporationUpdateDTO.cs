using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationUpdateDTO(
        int Id, 
        string CompanyName, 
        int AddressInfoId, 
        string PhoneNumber, 
        int CorporationTypeId,
        Int16 CorporatePackageTypeId, 
        byte IsActive,
        DateTime CreatedDate, 
        DateTime? ModifiedDate, 
        Guid CreatedBy, 
        Guid? ModifiedBy
        ){

        //public AddressInfo AddressInfo { get; init; }
        //public CorporationType CorporationType { get; init; }
        //public CorporatePackageType CorporatePackageType { get; init; }
       //public BaseUser BaseUser { get; init; } 
       // public BaseUser? BaseUser { get; init; }
}
}

