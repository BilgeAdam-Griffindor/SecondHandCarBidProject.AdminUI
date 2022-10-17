using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.StatusDtos
{
    public record StatusValueUpdateDto(int Id, string StatusName, int StatusTypeId, string StatusTypeName)
    {
        public List<SelectListItem> StatusTypeItemList { get; set; }
    }
}
