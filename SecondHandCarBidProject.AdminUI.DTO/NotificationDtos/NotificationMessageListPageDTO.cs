using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageListPageDTO(
        List<NotificationMessageUpdateDTO> TableRows,
        int maxPages);
}
