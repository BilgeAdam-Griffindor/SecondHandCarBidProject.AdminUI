using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos
{
    public record FavoriteUserSearchesUpdateDTO(
        Guid Id,
        string SearchText,
        Guid BaseUserId,
        bool IsActive,
        DateTime CreatedDate
        )
    {
        // public BaseUser BaseUser { get; init; }

    }

}
