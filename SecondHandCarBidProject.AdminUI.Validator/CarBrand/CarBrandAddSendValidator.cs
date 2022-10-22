using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBrand
{
    public class CarBrandAddSendValidator : AbstractValidator<CarBrandAddDTO>
    {
        public CarBrandAddSendValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
