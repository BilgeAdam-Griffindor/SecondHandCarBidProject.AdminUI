using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CorporationType
{
    public class CorporationTypeUpdateValidator: AbstractValidator<CorporationTypeUpdateDTO>
    {
        public CorporationTypeUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CorporationTypeName).NotEmpty();

        }
    }
}
