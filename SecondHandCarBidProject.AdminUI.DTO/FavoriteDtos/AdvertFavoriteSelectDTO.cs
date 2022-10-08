using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.FavoriteDtos
{
    public record AdvertFavoriteSelectDTO(Guid BaseUserId,string FirstName,string LastName,string UserName,DateTime CreatedDate,string AdvertTitle,string CarModel,string CarBrand)
    {
    }
}
