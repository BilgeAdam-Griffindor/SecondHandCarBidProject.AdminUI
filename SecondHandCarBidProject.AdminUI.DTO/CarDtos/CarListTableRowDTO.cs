using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarListTableRowDTO(
        Guid CarId,
        string BrandName,
        string ModelName,
        string IndividualOrCorporate,
        string Status,
        string Username,
        DateTime RegisterDate
        );
}
