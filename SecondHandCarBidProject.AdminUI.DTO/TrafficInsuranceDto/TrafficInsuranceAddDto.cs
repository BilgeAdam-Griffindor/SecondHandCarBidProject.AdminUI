using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto
{
    public record TrafficInsuranceAddDto(
        string CarId,
        string Cost,
        bool IsActive)
    {
        public List<SelectListItem> CarItemList { get; set; }
    }
}
