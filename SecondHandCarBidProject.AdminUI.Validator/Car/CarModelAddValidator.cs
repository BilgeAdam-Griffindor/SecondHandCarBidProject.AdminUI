using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarModelAddValidator : AbstractValidator<CarModelAddSendDTO>
    {
        public CarModelAddValidator()
        {
            RuleFor(x => x.CarBrandId).NotEmpty().WithMessage("Lütfen Marka Seçiniz");
            RuleFor(x => x.ModelName).NotNull().NotEmpty().WithMessage("Lütfen Model Giriniz");
        }
    }
}
