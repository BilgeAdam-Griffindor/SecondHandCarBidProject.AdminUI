using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBrand
{
    public class CarBrandUpdateSendValidator : AbstractValidator<CarBrandUpdateSendDTO>
    {
        public CarBrandUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
