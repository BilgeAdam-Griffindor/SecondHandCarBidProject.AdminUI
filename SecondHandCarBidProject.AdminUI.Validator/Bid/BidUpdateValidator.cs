using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Bid
{
    public class BidUpdateValidator : AbstractValidator<BidUpdateDTO>
    {
        public BidUpdateValidator()
        {
            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.BidName).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.EndDate).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.IsCorporate).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");

        }
    }
}
