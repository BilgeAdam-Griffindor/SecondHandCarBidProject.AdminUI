using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.NotificationDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.NotificationMessageUser
{
    public class NotificationMessageUserAddValidator : AbstractValidator<NotificationMessageUserAddDTO>
    {
        public NotificationMessageUserAddValidator()
        {
            RuleFor(x => x.NotificationMessageId).NotEmpty();
            RuleFor(x => x.SendToBaseUserId).NotEmpty();
        }
    }
}
