using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.BdOffer
{
    public class BidOfferUpdateSendValidator : AbstractValidator<BidOfferUpdateSendDTO>
    {
        public BidOfferUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.OfferAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BaseUserId).NotEmpty();
            RuleFor(x => x.BidId).NotEmpty();
            RuleFor(x => x.Explanation).NotEmpty();
        }
    }
}
