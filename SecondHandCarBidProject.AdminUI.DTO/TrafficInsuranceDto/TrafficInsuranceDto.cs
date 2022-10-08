using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto
{
    public record TrafficInsuranceDto(Guid Id,Guid CarId,string Cost,bool IsActive,DateTime CreatedDate,DateTime ModifiedDate, Guid CreatedBy, Guid ModifiedBy, List<TrafficInsuranceDto> TrafficInsuranceList)
    {
    }
}
