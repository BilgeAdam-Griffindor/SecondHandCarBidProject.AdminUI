using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.BdOffer
{
    public class BidOfferAddSendValidator : AbstractValidator<BidOfferAddSendDTO>
    {
        public BidOfferAddSendValidator()
        {
            RuleFor(x => x.OfferAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BaseUserId).NotEmpty();
            RuleFor(x => x.BidId).NotEmpty();
            RuleFor(x => x.Explanation).NotEmpty();
        }
    }
}
