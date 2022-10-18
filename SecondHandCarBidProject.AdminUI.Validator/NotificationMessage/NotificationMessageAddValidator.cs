using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.NotificationMessage
{
    public class NotificationMessageAddValidator:AbstractValidator<NotificationMessageAddDTO>
    {
        public NotificationMessageAddValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj içeriği alanı boş geçilemez...");

        }
    }
}
