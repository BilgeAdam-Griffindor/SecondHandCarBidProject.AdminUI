using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CorporationType
{
    public class CorporationTypeAddValidator: AbstractValidator<CorporationTypeAddDTO>
    {
        public CorporationTypeAddValidator()
        {
            RuleFor(x => x.CorporationTypeName).NotEmpty().WithMessage("Şirket Tipi alanı boş geçilemez...");
        }
    }
}
