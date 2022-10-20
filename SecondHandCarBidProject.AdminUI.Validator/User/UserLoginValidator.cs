using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;

namespace SecondHandCarBidProject.AdminUI.Validator.User
{
    public class UserLoginValidator : AbstractValidator<UserLoginAddDTO>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Lütfen boş bırakmayınız");
        }
    }
}
