using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarDetailUpdateSendValidator : AbstractValidator<CarDetailUpdateSendDTO>
    {
        public CarDetailUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Kilometre).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarYear).GreaterThanOrEqualTo((short)1950).LessThanOrEqualTo((short)DateTime.Now.Year);
            RuleFor(x => x.CarDescription).NotEmpty();
            RuleFor(x => x.CarBrandId).NotEmpty();
            RuleFor(x => x.CarModelId).NotEmpty();
            RuleFor(x => x.StatusId).NotEmpty();
            RuleFor(x => x.SelectedCarProperties).NotEmpty();
            RuleFor(x => x.CarImages).NotEmpty();
            When(x => x.IsCorporate, () =>
            {
                RuleFor(x => x.CorporationId).NotEmpty();
            });
        }
    }
}
