using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.BidStatusHistory
{
    public class BidStatusHistoryAddSendValidator : AbstractValidator<BidStatusHistoryAddSendDTO>
    {
        public BidStatusHistoryAddSendValidator()
        {
            RuleFor(x => x.BidId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.StatusValueId).NotEmpty().WithMessage("Boş olamaz.");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Boş olamaz.");
        }
    }
}
