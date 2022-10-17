using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Bid
{
    public class BidAddValidator : AbstractValidator<BidAddDto>
    {
        public BidAddValidator()
        {
            RuleFor(x => x.BidEndDate).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.BidName).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.BidStartDate).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.IsCorporate).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");

        }
    }
}
