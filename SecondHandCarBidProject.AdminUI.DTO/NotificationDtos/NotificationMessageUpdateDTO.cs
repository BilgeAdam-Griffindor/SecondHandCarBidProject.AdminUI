using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.NotificationDtos
{
    public record NotificationMessageUpdateDTO(
        int Id,
        string Content,
        bool IsActive,
        DateTime? ModifiedDate,
        Guid? ModifiedBy
    )
    {
        // public BaseUser? BaseUser { get; init; }

    }
}
