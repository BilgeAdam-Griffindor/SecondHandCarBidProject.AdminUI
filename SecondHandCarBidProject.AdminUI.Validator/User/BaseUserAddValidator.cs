using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.User
{
    public class BaseUserAddValidator : AbstractValidator<BaseUserAddDTO>
    {
        public BaseUserAddValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.SurName).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız").EmailAddress().WithMessage("Lütfen düzgün e-mail adresi giriniz.");
        }
    }
}
