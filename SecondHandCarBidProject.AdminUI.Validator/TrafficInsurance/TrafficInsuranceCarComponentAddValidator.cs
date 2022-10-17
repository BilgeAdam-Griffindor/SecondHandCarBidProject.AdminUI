using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;

namespace SecondHandCarBidProject.AdminUI.Validator.TrafficInsurance
{
    public class TrafficInsuranceCarComponentAddValidator:AbstractValidator<TrafficInsuranceCarComponentAddDto>
    {
        public TrafficInsuranceCarComponentAddValidator()
        {
            RuleFor(x => x.ComponentName).NotNull().NotEmpty().Custom((x, context) =>
            {

                if (x.Any(char.IsDigit))
                {
                    context.AddFailure("You can't use any digit in here!");
                }
            });
        }
    }
}
