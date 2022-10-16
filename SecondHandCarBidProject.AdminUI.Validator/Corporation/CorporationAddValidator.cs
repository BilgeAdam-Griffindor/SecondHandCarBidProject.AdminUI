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
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.AddressInfoId).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.CorporationTypeId).NotEmpty();
            RuleFor(x => x.CorporatePackageTypeId).NotEmpty();
        }
    }
}
