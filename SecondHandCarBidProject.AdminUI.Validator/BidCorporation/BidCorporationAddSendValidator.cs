using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.BidCorporation
{
    public class BidCorporationAddSendValidator : AbstractValidator<BidCorporationAddSendDTO>
    {
        public BidCorporationAddSendValidator()
        {
            RuleFor(x => x.BidId).NotEmpty();
            RuleFor(x => x.CorporationId).NotEmpty();
        }
    }
}
