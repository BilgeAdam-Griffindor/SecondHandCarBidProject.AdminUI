using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporationTypeAddPageDTO(string CorporationTypeName, Guid CreatedBy,List<IdNameListDTO> CreatedByList);
}
