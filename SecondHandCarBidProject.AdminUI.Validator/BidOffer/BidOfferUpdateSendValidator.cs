using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.BdOffer
{
    public class BidOfferUpdateSendValidator : AbstractValidator<BidOfferUpdateSendDTO>
    {
        public BidOfferUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.OfferAmount).GreaterThanOrEqualTo(0).WithMessage("Negatif olamaz.");
            RuleFor(x => x.BaseUserId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.BidId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
