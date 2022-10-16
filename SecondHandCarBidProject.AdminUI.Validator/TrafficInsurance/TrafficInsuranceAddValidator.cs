using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.TrafficInsuranceDto;

namespace SecondHandCarBidProject.AdminUI.Validator.TrafficInsurance
{
    public class TrafficInsuranceAddValidator: AbstractValidator<TrafficInsuranceAddDto>
    {
        //RuleFor(x => x.ActionAuthTypeId.HasValue? x.ActionAuthTypeId.ToString() : "").Matches("^\\d+$").WithMessage("Sayı girilmeli");
        public TrafficInsuranceAddValidator()
        {
            RuleFor(x => x.Cost.HasValue ? x.Cost.ToString() : "").Matches("\\d+\\.?\\d*$").WithMessage("Sayı girilmeli");
        }
    }
}
