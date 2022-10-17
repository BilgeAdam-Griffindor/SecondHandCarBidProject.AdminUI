using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBuy
{
    public class CarBuyAddSendValidator : AbstractValidator<CarBuyAddSendDTO>
    {
        public CarBuyAddSendValidator()
        {
            RuleFor(x => x.Kilometre).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarYear).GreaterThanOrEqualTo((short)1950).LessThanOrEqualTo((short)DateTime.Now.Year);
            RuleFor(x => x.CarDescription).NotEmpty();
            RuleFor(x => x.CarBrandId).NotEmpty();
            RuleFor(x => x.CarModelId).NotEmpty();
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
        }
    }
}
