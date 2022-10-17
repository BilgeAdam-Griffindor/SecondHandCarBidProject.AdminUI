using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.UserAutoBid
{
    public class UserAutoBidUpdateValidation: AbstractValidator<UserAutoBidUpdateDto>
    {
        public UserAutoBidUpdateValidation()
        {
            RuleFor(x => x.MaximumOffer.HasValue ? x.MaximumOffer.ToString() : "").Matches("\\d+\\.?\\d*$").WithMessage("Sayı girilmeli");
            RuleFor(x => x.IncrementAmount.HasValue ? x.IncrementAmount.ToString() : "").Matches("\\d+\\.?\\d*$").WithMessage("Sayı girilmeli");
        }
    }
}
