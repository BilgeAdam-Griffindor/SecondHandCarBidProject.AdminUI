using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CorporationUser
{
    public class CorporationUserUpdateValidator:AbstractValidator<CorporationUserUpdateDTO>
    {
        public CorporationUserUpdateValidator()
        {
            RuleFor(x => x.BaseUserId).NotEmpty(); 
            RuleFor(x => x.CorporationId).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
            RuleFor(x => x.ModifiedBy).NotEmpty();
        }
    }
}
