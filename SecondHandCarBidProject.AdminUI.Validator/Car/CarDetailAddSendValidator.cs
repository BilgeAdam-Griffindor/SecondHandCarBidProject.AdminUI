using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarDetailAddSendValidator : AbstractValidator<CarDetailAddSendDTO>
    {
        public CarDetailAddSendValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Kilometre).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarYear).GreaterThanOrEqualTo(ValidationValues.minYear).LessThanOrEqualTo(ValidationValues.maxYear);
            RuleFor(x => x.CarDescription).NotEmpty();
            RuleFor(x => x.CarBrandId).NotEmpty();
            RuleFor(x => x.CarModelId).NotEmpty();
            RuleFor(x => x.StatusId).NotEmpty();
            RuleFor(x => x.BodyTypeId).NotEmpty();
            RuleFor(x => x.FuelTypeId).NotEmpty();
            RuleFor(x => x.GearTypeId).NotEmpty();
            RuleFor(x => x.VersionId).NotEmpty();
            RuleFor(x => x.ColorId).NotEmpty();
            RuleFor(x => x.CarImages).NotEmpty().Must(x => x.Count <= ValidationValues.maxImageCount);
            RuleForEach(x => x.CarImages).ChildRules(x =>
            {
                x.RuleFor(x => x.Length).NotEmpty().LessThan(ValidationValues.maxImageSize);
            });
            When(x => x.IsCorporate, () =>
            {
                RuleFor(x => x.CorporationId).NotEmpty();
            });
            When(x => !x.IsCorporate, () =>
            {
                RuleFor(x => x.CorporationId).Empty();
            });
        }
    }
}
