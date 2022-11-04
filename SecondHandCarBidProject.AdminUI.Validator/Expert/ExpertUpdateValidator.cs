using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Expert
{
    public class ExpertUpdateValidator:AbstractValidator<ExpertInfoUpdateDTO>
    {
        public ExpertUpdateValidator()
        {
            RuleFor(x => x.AddressInfoId).NotEmpty().WithMessage("Bu alan boş geçilemez...");
            RuleFor(x => x.CreatedBy).NotEmpty(); 
            RuleFor(x => x.ModifiedBy).NotEmpty();
        }
    }
}
