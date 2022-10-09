using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.StatusDtos
{
    public record StatusValueDto(int Id,string StatusName,int StatusTypeId,bool IsActive,List<StatusValueDto> StatusValueList)
    {
        public StatusTypeDto StatusTypeDto { get; init; }
    }
}
