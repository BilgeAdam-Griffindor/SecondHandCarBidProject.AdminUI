using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto
{
    public record TrafficInsuranceTrafficInsuranceCarComponentDto(
        Guid TrafficInsuranceId,
        Int16 TrafficInsuranceCarComponentId,
        string TrafficInsuranceCarComponentName,
        int StatusValueId,
        string StatusValueName)
    {
    }
}
