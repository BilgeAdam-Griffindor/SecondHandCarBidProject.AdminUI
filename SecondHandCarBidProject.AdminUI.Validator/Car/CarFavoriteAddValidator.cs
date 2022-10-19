using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarFavoriteAddValidator : AbstractValidator<CarFavoriteAddSendDTO>
    {
        public CarFavoriteAddValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Lütfen Araba Seçiniz");
            RuleFor(x => x.BaseUserId).NotEmpty().WithMessage("Lütfen Kullanıcı Seçiniz");
        }
    }
}
