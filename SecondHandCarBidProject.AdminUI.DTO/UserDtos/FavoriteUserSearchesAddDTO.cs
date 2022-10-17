using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos
{
    public record FavoriteUserSearchesAddDTO(
        string SearchText,
        Guid BaseUserId,
        DateTime CreatedDate)
        {
            // public BaseUser BaseUser { get; init; }

        }
    
}
