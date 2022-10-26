using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.User
{
    public class UserLoginValidator : AbstractValidator<TokenUserRequestDTO>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.LoginUser).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.LoginPassword).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
        }
    }
}
