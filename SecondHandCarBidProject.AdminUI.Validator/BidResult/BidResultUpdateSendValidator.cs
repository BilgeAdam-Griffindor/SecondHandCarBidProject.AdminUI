using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.BidResult
{
    public class BidResultUpdateSendValidator : AbstractValidator<BidResultUpdateSendDTO>
    {
        public BidResultUpdateSendValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Explanation).NotEmpty();
        }
    }
}
