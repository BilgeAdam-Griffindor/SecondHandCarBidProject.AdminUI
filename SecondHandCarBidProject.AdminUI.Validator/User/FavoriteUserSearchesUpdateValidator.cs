using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.User
{
    public class FavoriteUserSearchesUpdateValidator: AbstractValidator<FavoriteUserSearchesUpdateDTO>
    {
        public FavoriteUserSearchesUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); 
            RuleFor(x => x.SearchText).NotEmpty();
            RuleFor(x => x.BaseUserId).NotEmpty();
        }
    }
}
