using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto
{
    public record TrafficInsuranceTrafficInsuranceCarComponentAddDto(
         Guid? TrafficInsuranceId,
        Int16? TrafficInsuranceCarComponentId,
        int? StatusValueId)
    {
        public List<SelectListItem> TrafficInsuranceItemList { get; set; }
        public List<SelectListItem> TrafficInsuranceCarComponentItemList { get; set; }
        public List<SelectListItem> StatusValueItemList { get; set; }
    }
}
