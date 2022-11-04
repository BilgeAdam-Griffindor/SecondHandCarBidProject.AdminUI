using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUpdatePageDTO(int Id,
        string Content,
        bool IsActive,
        DateTime? ModifiedDate,
        Guid? ModifiedBy,
                List<IdNameListDTO> ModifiedByList);
}
