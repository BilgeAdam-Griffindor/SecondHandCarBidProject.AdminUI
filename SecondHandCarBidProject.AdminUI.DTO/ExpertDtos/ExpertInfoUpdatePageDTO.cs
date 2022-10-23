using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.ExpertDtos
{
    public record ExpertInfoUpdatePageDTO(int Id,
        string? CentreName,
        int AddressInfoId,
        decimal? Longitude,
        decimal? Latitude,
        byte[]? Picture,
        bool IsActive,
        string? ExpertAddress,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy,
          List<IdNameListDTO> AddressInfoList,
        List<IdNameListDTO> CreatedByList,
        List<IdNameListDTO> ModifiedByList);
}
