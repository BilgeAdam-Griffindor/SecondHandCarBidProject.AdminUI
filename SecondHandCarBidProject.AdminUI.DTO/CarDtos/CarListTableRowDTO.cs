using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public record CarListTableRowDTO(
        Guid CarId,
        string CarBrandName,
        string CarModelName,
        string Status,
        string UserFullName,
        DateTime RegisterDate
        );
}
