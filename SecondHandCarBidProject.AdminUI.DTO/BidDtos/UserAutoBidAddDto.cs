using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.BidDtos
{
    public record UserAutoBidAddDto(
        decimal? MaximumOffer,
        decimal? IncrementAmount,
        Guid? BaseUserId,
        Guid? BidId)
    {
        public List<SelectListItem> BaseUserItemList { get; set; }
        public List<SelectListItem> BidItemList { get; set; }
    }
}
