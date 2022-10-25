using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AboutUs
{
    public record AboutUsListPageDTO(List<CorporatePackageTypeUpdateDTO> TableRows,
        int maxPages);
}
