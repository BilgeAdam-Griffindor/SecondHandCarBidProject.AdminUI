﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.CorporationDtos
{
    public record CorporatePackageTypeListPageDTO(
        List<CorporatePackageTypeUpdateDTO> TableRows,
        int maxPages);
}
