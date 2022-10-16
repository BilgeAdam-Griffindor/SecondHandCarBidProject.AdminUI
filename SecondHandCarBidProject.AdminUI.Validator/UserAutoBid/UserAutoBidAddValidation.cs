using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.UserAutoBid
{
    public class UserAutoBidAddValidation: AbstractValidator<UserAutoBidAddDto>
    {
        public UserAutoBidAddValidation()
        {
            RuleFor(x => x.MaximumOffer.HasValue ? x.MaximumOffer.ToString() : "").Matches("\\d+\\.?\\d*$").WithMessage("Sayı girilmeli");
            RuleFor(x => x.IncrementAmount.HasValue ? x.IncrementAmount.ToString() : "").Matches("\\d+\\.?\\d*$").WithMessage("Sayı girilmeli");
        }
    }
}
