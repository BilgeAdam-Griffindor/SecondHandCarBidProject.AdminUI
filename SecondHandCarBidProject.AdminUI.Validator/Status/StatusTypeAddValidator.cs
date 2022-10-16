using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.StatusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Status
{
    public class StatusTypeAddValidator: AbstractValidator<StatusTypeAddDto>
    {
        public StatusTypeAddValidator()
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
