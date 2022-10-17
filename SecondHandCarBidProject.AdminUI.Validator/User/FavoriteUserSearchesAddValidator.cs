﻿using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.User
{
    public class FavoriteUserSearchesAddValidator: AbstractValidator<FavoriteUserSearchesAddDTO>
    {
        public FavoriteUserSearchesAddValidator()
        {
            RuleFor(x => x.SearchText).NotEmpty();
            RuleFor(x => x.BaseUserId).NotEmpty();
        }
    }
}