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
            RuleFor(x => x.BidId).NotEmpty();
            RuleFor(x => x.StatusValueId).NotEmpty();
            RuleFor(x => x.Explanation).NotEmpty();
        }
    }
}
