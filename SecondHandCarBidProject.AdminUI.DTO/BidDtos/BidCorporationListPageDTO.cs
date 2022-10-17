using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{

    public record BidCorporationListPageDTO(
        List<BidCorporationListTableRowsDTO> TableRows,
        int maxPages
        );
}
