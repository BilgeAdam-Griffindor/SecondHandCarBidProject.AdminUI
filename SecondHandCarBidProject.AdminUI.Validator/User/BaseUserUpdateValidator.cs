using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.User
{
    public class BaseUserUpdateValidator : AbstractValidator<BaseUserUpdateDTO>
    {
        public BaseUserUpdateValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.SurName).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
           
        }
    }
}
