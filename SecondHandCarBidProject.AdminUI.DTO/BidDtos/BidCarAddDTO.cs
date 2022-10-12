using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidCarAddDTO(Guid BidId,List<CarListTableRowDTO> Cars,DateTime CreatedDate,decimal BidStartPrice,decimal MinumumBuyPrice,bool IsActive,Guid CreatedBy)
    {
    }
}
