using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUserListPageDTO(
        List<NotificationMessageUserUpdateDTO> TableRows,
        int maxPages);
}
