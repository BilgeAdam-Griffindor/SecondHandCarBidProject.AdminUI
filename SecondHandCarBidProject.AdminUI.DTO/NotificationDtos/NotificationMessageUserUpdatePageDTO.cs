using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUserUpdatePageDTO(Guid Id,
        int NotificationMessageId,
        Guid SendToBaseUserId,
        bool IsActive,
        DateTime CreatedDate,
        Guid CreatedBy,
        List<IdNameListDTO> NotificationMessageList, 
        List<IdNameListDTO> SendToBaseUserList, 
        List<IdNameListDTO> CreatedByList
        );
}
