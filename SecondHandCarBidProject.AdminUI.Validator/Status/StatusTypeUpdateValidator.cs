using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Status
{
    public class StatusTypeUpdateValidator: AbstractValidator<StatusTypeUpdate>
    {
        public StatusTypeUpdateValidator()
        {
            RuleFor(x => x.StatusTypeName).NotNull().NotEmpty().Custom((x, context) =>
            {

                if (x.Any(char.IsDigit))
                {
                    context.AddFailure("You can't use any digit in here!");
                }
            });
        }
    }
}
