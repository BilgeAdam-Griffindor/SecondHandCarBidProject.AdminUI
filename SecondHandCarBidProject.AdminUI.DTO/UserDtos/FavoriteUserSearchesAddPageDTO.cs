using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos
{
    public record FavoriteUserSearchesAddPageDTO(string SearchText,
        Guid BaseUserId,
        DateTime CreatedDate,
        List<IdNameListDTO> BaseUserList
        );
}
