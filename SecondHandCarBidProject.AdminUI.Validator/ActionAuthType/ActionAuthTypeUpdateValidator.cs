using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.ActionAuthType
{
    public class ActionAuthTypeUpdateValidator:AbstractValidator<ActionAuthTypeUpdateDTO>
    {
        public ActionAuthTypeUpdateValidator()
        {
            RuleFor(x => x.id).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.AuthorizationName).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.IsActive).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
        }
    }
}
