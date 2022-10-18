using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.ExpertDtos
{
    public record ExpertInfoListPageDTO(
        List<ExpertInfoUpdateDTO> TableRows,
        int maxPages);
}
