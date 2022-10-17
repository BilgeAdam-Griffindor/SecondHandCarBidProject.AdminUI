using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CorporationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CorporatePackageType
{
    public class CorporatePackageTypeUpdateValidator: AbstractValidator<CorporatePackageTypeUpdateDTO>
    {
        public CorporatePackageTypeUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.PackageName).NotEmpty();
        }
    }
}
