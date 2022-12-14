using SecondHandCarBidProject.AdminUI.DTO.CarDtos;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record BidUpdateDTO(Guid Id,string BidName,bool IsCorporate,DateTime StartDate,DateTime EndDate,
        bool IsApproved,DateTime ModifiedDate,List<CarDetailAddSendDTO> cars, List<StatusTypeDto> status
        )
    {

    }
}
