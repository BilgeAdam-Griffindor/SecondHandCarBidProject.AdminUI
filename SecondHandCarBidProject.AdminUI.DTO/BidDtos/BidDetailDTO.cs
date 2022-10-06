using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidDetailDTO(string BidName,bool IsCorporate,DateTime StartDate, DateTime EndDate,bool IsApproved,
        Guid ApprovedAdmin,string AdminName,DateTime VerificationDate,DateTime CreatedDate,
        List<CarDetailDto>Cars
        )
    {
        //List<BiddStatusHistoryDTO> Eklenir
        //List<OffersDto>Eklenir
        // BidAdditionFee Eklenir
    }
}
