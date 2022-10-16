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
            RuleFor(x => x.SelectedCarProperties).NotEmpty();
            RuleFor(x => x.CarImages).NotNull().NotEmpty().Must(x => x.Count <= 5);
        }
    }
}
