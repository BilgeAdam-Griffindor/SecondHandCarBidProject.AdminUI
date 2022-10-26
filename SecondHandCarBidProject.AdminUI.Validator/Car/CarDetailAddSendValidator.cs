using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;

namespace SecondHandCarBidProject.AdminUI.Validator.Car
{
    public class CarDetailAddSendValidator : AbstractValidator<CarDetailAddSendDTO>
    {
        public CarDetailAddSendValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Negatif olamaz.");
            RuleFor(x => x.Kilometre).GreaterThanOrEqualTo(0).WithMessage("Negatif olamaz.");
            RuleFor(x => x.CarYear).GreaterThanOrEqualTo(ValidationValues.minYear).WithMessage(ValidationValues.minYear + "'dan küçük olamaz.")
                .LessThanOrEqualTo(ValidationValues.maxYear).WithMessage(ValidationValues.maxYear + "'dan büyük olamaz.");
            RuleFor(x => x.CarDescription).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.CarBrandId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.CarModelId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.StatusId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.BodyTypeId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.FuelTypeId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.GearTypeId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.VersionId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.ColorId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.CarImages).NotEmpty().WithMessage("Boş olamaz.")
                .Must(x => x.Count <= ValidationValues.maxImageCount).WithMessage("En fazla " + ValidationValues.maxImageCount + " resim ekleyebilirsiniz.");
            RuleForEach(x => x.CarImages).ChildRules(x =>
            {
                x.RuleFor(x => x.Length).NotEmpty().WithMessage("Boş resim dosyası girilemez.")
                .LessThan(ValidationValues.maxImageSizeInBytes).WithMessage("Resim dosyası " + ValidationValues.maxImageSizeInMB + "MB'tan büyük olamaz.");
            });
            When(x => x.IsCorporate, () =>
            {
                RuleFor(x => x.CorporationId).NotEmpty().WithMessage("Kurumsal seçilirse kurum boş olamaz.");
            });
            When(x => !x.IsCorporate, () =>
            {
                RuleFor(x => x.CorporationId).Empty().WithMessage("Bireysel seçilirse kurum seçilemez.");
            });
        }
    }
}
