using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarPropertyAddValidator : AbstractValidator<CarPropertyAddSendDTO>
    {
        public CarPropertyAddValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Lütfen Araba Seçiniz");
            RuleFor(x => x.CarPropertyValueId).NotEmpty().WithMessage("Lütfen Özellik Seçiniz");
        }
    }
}
