using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record NotaryFeeAddPageDTO(decimal FeeAmount,
        DateTime StartDate,
        DateTime EndDate,
        DateTime CreatedDate,
        Guid CreatedBy,
        List<IdNameListDTO> CreatedByList,
        List<IdNameListDTO> ModifiedByList); 
}
