using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AdvertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.AdvertInfo
{
    public class AdvertInfoUpdateValidator:AbstractValidator<AdvertUpdateDTO>
    {
        public AdvertInfoUpdateValidator()
        {
            
            RuleFor(x => x.AdvertDescription).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.id).NotNull().NotEmpty();
            RuleFor(x => x.AdvertTitle).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.CreatedDate).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.IsActive).NotEmpty().NotNull().WithMessage("Lütfen boş bırakmayınız");
        }
    }
}
