using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarPropertyValueAddValidator : AbstractValidator<CarPropertyValueAddSendDTO>
    {
        public CarPropertyValueAddValidator()
        {
            RuleFor(x => x.TopPropertyValueId).NotEmpty().WithMessage("Lütfen Kategori Seçiniz");
            RuleFor(x => x.PropertyValue).NotNull().NotEmpty().WithMessage("Lütfen Parça Giriniz");
        }
    }
}
