using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarCorporationAddValidator : AbstractValidator<CarCorporationAddSendDTO>
    {
        public CarCorporationAddValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Lütfen Araba Seçiniz");
            RuleFor(x => x.CorporationId).NotEmpty().WithMessage("Lütfen Şirket Seçiniz");
        }
    }
}
