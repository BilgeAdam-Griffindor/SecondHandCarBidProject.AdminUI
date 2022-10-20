using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUserUpdateDTO(
        Guid Id,
        int NotificationMessageId, 
        Guid SendToBaseUserId,
        bool IsActive,
        DateTime CreatedDate, 
        Guid CreatedBy
        )
    {
        //public NotificationMessage NotificationMessage { get; init; }
        //public BaseUser BaseUser { get; init; }

    }
}
