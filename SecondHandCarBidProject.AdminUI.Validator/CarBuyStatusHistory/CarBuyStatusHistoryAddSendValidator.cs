using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.CarBuyStatusHistory
{
    public class CarBuyStatusHistoryAddSendValidator : AbstractValidator<CarBuyStatusHistoryAddSendDTO>
    {
        public CarBuyStatusHistoryAddSendValidator()
        {
            RuleFor(x => x.CarBuyId).NotEmpty();
            RuleFor(x => x.StatusValueId).NotEmpty();
            RuleFor(X => X.Explanation).NotEmpty();
        }
    }
}
