using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarStatusHistoryAddValidator : AbstractValidator<CarStatusHistoryAddSendDTO>
    {
        public CarStatusHistoryAddValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Lütfen Araba Seçiniz");
            RuleFor(x => x.StatusValueId).NotEmpty().WithMessage("Lütfen Statü Seçiniz");
            RuleFor(x => x.Explanation).NotNull().NotEmpty().WithMessage("Lütfen Açıklama Giriniz");
        }
    }
}
