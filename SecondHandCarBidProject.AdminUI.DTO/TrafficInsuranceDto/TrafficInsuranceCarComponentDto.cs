using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto
{
    public record TrafficInsuranceCarComponentDto(Int16 Id, string ComponentName,bool IsActive,List<TrafficInsuranceCarComponentDto> TrafficInsuranceCarComponentList)
    {
    }
}
