using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CorporatePackageType
{
    public class CorporatePackageTypeAddValidator:AbstractValidator<CorporatePackageTypeAddDTO>
    {
        public CorporatePackageTypeAddValidator()
        {
            RuleFor(x => x.PackageName).NotEmpty().WithMessage("Paket adı alanı boş geçilemez...");
            RuleFor(x => x.CountOfBids).NotEmpty().WithMessage("İhale sayısı en az 3 olmalıdır.");
            RuleFor(x => x.CreatedBy).NotEmpty();

        }
    }
}
