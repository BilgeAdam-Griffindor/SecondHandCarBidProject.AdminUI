﻿using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.PageAuthType
{
    public class PageAuthTypeAddValidator: AbstractValidator<PageAuthTypeAdd>
    {
        public PageAuthTypeAddValidator()
        {
            RuleFor(x => x.AuthorizationName).NotNull().NotEmpty().Custom((x,context) =>
            {

                if (x.Any(char.IsDigit))
                {
                    context.AddFailure("You can't use any digit in here!");
                }
            });
           
        }
    }
}
