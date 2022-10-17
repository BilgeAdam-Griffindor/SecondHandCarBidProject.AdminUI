using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.AdditionalFee
{
    public class BidadditionalFeeAddValidator: AbstractValidator<BidAdditionalFeeAddDTO>
    {
        public BidadditionalFeeAddValidator()
        {
            RuleFor(x => x.BidId).NotNull().NotEmpty();
            RuleFor(x => x.NotaryFeeId).NotNull().NotEmpty();
            RuleFor(x => x.CommisionId).NotNull().NotEmpty();

        }
    }
}
