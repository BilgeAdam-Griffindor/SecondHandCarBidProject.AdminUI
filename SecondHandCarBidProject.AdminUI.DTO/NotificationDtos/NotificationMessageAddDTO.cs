using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageAddDTO(
    string Content,
    DateTime? ModifiedDate,
    Guid? ModifiedBy)
    {
            // public BaseUser? BaseUser { get; init; }
    }
}
