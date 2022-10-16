using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SecondHandCarBidProject.AdminUI.Validator.RolePageActionAuth
{
    public class RolePageActionAuthAddValidator:AbstractValidator<RolePageActionAuthAddDto>
    {
        public RolePageActionAuthAddValidator()
        {
            RuleFor(x => x.ActionAuthTypeId.HasValue ? x.ActionAuthTypeId.ToString() : "").Matches("^\\d+$").WithMessage("Sayı girilmeli");
            RuleFor(x => x.PageAuthTypeId.HasValue ? x.PageAuthTypeId.ToString() : "").Matches("^\\d+$").WithMessage("Sayı girilmeli");
            RuleFor(x => x.RoleTypeId.HasValue ? x.RoleTypeId.ToString() : "").Matches("^\\d+$").WithMessage("Sayı girilmeli");
        }
    }
}
