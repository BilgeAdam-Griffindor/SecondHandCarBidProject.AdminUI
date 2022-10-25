using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AboutUs
{
    public record AboutUsAddPageDTO(string HeadLine1,
        string Content1,
        string HeadLine2,
        string Content2,
        bool IsActive,
        DateTime CreatedDate,
        DateTime? ModifiedDate,
        Guid CreatedBy,
        Guid? ModifiedBy,
        List<IdNameListDTO> CreatedByList,
        List<IdNameListDTO> ModifiedByList);
}
