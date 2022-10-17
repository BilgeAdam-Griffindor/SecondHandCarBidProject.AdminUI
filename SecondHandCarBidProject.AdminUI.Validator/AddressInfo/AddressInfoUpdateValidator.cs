using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.AddressInfo
{
    public class AddressInfoUpdateValidator:AbstractValidator<AddressInfoUpdateDTO>
    {
        public AddressInfoUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.AddressName).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.AddressTypeId).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.TopAddresses).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
        }
    }
}
