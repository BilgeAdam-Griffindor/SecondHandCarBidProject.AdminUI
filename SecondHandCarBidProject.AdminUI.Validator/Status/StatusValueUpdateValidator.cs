using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.Status
{
    public class StatusValueUpdateValidator: AbstractValidator<StatusValueUpdateDto>
    {
        public StatusValueUpdateValidator()
        {
            RuleFor(x => x.StatusName).NotNull().NotEmpty().Custom((x, context) =>
            {

                if (x.Any(char.IsDigit))
                {
                    context.AddFailure("You can't use any digit in here!");
                }
            });
        }
    }
}
