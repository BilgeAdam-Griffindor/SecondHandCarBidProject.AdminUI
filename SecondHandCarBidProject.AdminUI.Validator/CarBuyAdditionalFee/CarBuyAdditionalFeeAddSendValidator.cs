using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBuyAdditionalFee
{
    public class CarBuyAdditionalFeeAddSendValidator : AbstractValidator<CarBuyAdditionalFeeAddSendDTO>
    {
        public CarBuyAdditionalFeeAddSendValidator()
        {
            RuleFor(x => x.CarBuyId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.NotaryFeeId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.CommissionFeeId).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
