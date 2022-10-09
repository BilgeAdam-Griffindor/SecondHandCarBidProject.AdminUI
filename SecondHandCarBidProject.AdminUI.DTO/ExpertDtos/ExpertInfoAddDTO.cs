using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.ExpertDtos
{
    public record ExpertInfoAddDTO(
        string? CentreName,
        int AddressInfoId,
        decimal? Longitude,
        decimal? Latitude,
        byte[]? Picture,
        byte IsActive,
        string? ExpertAddress,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy
        )
    {
        //public AddressInfo AddressInfo { get; init; }
        //public BaseUser BaseUser { get; init; } 
        // public BaseUser? BaseUser { get; init; } 
    }
}
