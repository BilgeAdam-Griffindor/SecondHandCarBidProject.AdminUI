using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUserAddDTO(
        int NotificationMessageId,
        Guid SendToBaseUserId,
        byte IsActive,
        DateTime CreatedDate,
        Guid CreatedBy
        )
    {
        //public NotificationMessage NotificationMessage { get; init; }
        //public BaseUser BaseUser { get; init; }
    }
}
