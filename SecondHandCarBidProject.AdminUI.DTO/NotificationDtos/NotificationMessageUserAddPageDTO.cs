using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUserAddPageDTO(int NotificationMessageId,
        Guid SendToBaseUserId,
        DateTime CreatedDate,
        Guid CreatedBy,
         List<IdNameListDTO> NotificationMessageList,
        List<IdNameListDTO> SendToBaseUserList,
        List<IdNameListDTO> CreatedByList
        );
}
