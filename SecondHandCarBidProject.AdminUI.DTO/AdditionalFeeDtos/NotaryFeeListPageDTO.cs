using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos
{
    public record NotaryFeeListPageDTO(
        List<NotaryFeeUpdateDTO> TableRows,
        int maxPages);
}
