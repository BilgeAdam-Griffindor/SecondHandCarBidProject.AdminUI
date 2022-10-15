using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBrand
{
    public class CarBrandUpdateSendValidator : AbstractValidator<CarBrandUpdateDTO>
    {
        public CarBrandUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.BrandName).NotEmpty();
        }
    }
}
