using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarSoldToAddValidator : AbstractValidator<CarSoldToAddSendDTO>
    {
        public CarSoldToAddValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Lütfen Araba Seçiniz");
            RuleFor(x => x.SoldToBaseUserId).NotEmpty().WithMessage("Lütfen Kullanıcı Seçiniz");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Lütfen 0 dan Büyük Sayı Giriniz");
        }
    }
}
