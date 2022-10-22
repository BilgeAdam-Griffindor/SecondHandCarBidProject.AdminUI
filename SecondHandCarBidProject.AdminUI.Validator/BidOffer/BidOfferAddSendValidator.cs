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
            RuleFor(x => x.OfferAmount).GreaterThanOrEqualTo(0).WithMessage("Negatif olamaz.");
            RuleFor(x => x.BaseUserId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.BidId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
