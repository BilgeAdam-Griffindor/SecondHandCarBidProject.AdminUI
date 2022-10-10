﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto
{
    public record TrafficInsuranceTrafficInsuranceCarComponentDto(Guid TrafficInsuranceId, Int16 TrafficInsuranceCarComponentId,int StatusValueId,bool IsActive, DateTime CreatedDate,DateTime ModifiedDate, Guid CreatedBy,Guid ModifiedBy, List<TrafficInsuranceTrafficInsuranceCarComponentDto> TrafficInsuranceTrafficInsuranceCarComponentList)
    {
    }
}