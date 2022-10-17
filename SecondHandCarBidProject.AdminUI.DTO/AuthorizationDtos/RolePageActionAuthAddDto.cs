using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public record RolePageActionAuthAddDto(
        Int16? RoleTypeId,
        Int16? PageAuthTypeId,
        Int16? ActionAuthTypeId)
    {
        public List<SelectListItem> RoleTypeItemList
        {
            get; set;
        }
        public List<SelectListItem> PageAuthTypeItemList
        {
            get; set;
        }
        public List<SelectListItem> ActionAuthTypeItemList
        {
            get; set;
        }
    }
}
