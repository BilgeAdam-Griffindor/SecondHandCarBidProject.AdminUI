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
        decimal? Cost)
    {
        public List<SelectListItem> CarItemList { get; set; }
    }
}
