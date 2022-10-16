using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.NotificationMessageUser
{
    public class NotificationMessageUserUpdateValidator: AbstractValidator<NotificationMessageUserUpdateDTO>
    {
        public NotificationMessageUserUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); 
            RuleFor(x => x.NotificationMessageId).NotEmpty();
            RuleFor(x => x.SendToBaseUserId).NotEmpty();
        }
    }
}
