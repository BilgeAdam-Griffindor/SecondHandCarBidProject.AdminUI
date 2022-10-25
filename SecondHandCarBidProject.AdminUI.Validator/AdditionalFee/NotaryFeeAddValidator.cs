using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AdditionalFeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.AdditionalFee
{
    public class NotaryFeeAddValidator:AbstractValidator<NotaryFeeAddDTO>
    {
        public NotaryFeeAddValidator()
        {
            RuleFor(x => x.FeeAmount).GreaterThanOrEqualTo(0).NotEmpty().WithMessage("Noter ücret alanı boş geçilemez...");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş geçilemez...");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş geçilemez...");
            RuleFor(x => x.CreatedDate).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
