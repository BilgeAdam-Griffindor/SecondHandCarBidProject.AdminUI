using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.BidResult
{
    public class BidResultAddSendValidator : AbstractValidator<BidResultAddSendDTO>
    {
        public BidResultAddSendValidator()
        {
            RuleFor(x => x.BidOfferId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
