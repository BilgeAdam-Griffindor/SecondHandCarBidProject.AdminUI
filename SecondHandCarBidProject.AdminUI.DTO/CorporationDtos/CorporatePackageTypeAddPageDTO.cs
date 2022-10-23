using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporatePackageTypeAddPageDTO(string PackageName, Guid CreatedBy, Int16? CountOfBids,List<IdNameListDTO> CreatedByList);
}
