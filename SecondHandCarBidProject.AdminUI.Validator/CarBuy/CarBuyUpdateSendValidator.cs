using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBuy
{
    public class CarBuyUpdateSendValidator : AbstractValidator<CarBuyUpdateSendDTO>
    {
        public CarBuyUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.StatusId).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
