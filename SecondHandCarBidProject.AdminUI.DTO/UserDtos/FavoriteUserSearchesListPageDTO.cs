using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.UserDtos
{
    public record FavoriteUserSearchesListPageDTO(
        List<FavoriteUserSearchesUpdateDTO> TableRows,
        int maxPages);
}
