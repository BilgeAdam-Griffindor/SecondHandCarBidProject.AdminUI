using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Corporation
{
    public class CorporationAddValidator: AbstractValidator<CorporationAddDTO>
    {
        public CorporationAddValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket adı alanı boş geçilemez...");
            RuleFor(x => x.AddressInfoId).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası alanı boş geçilemez...");
            RuleFor(x => x.CorporationTypeId).NotEmpty();
            RuleFor(x => x.CorporatePackageTypeId).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
