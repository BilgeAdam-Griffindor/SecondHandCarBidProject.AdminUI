using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.AdditionalFee
{
    public class NotaryFeeUpdateValidator : AbstractValidator<NotaryFeeUpdateDTO>
    {
        public NotaryFeeUpdateValidator()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.FeeAmount).GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.CreatedDate).NotEmpty();
        }
    }
}
