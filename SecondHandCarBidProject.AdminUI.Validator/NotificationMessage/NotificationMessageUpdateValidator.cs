using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.NotificationMessage
{
    public class NotificationMessageUpdateValidator:AbstractValidator<NotificationMessageUpdateDTO>
    {
        public NotificationMessageUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); 
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
