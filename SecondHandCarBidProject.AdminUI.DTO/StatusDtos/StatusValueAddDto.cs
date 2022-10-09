﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.StatusDtos
{
    public record StatusValueAddDto(string StatusName, int StatusTypeId, bool IsActive)
    {
        public List<SelectListItem> StatusTypeList { get; set; }
    }
}
