using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.CarDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarImagesAddValidator : AbstractValidator<CarImagesAddSendDTO>
    {
        public CarImagesAddValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Lütfen Araba Seçiniz");
            RuleFor(x => x.CarImage).NotEmpty().Must(x => x.Length < ValidationValues.maxImageSize).WithMessage("Lütfen 1 MB Boyutundan Küçük Resim Seçiniz");
        }
    }
}
