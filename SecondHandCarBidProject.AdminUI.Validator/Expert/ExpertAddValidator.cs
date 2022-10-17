﻿using FluentValidation;
using SecondHandCarBidProject.AdminUI.DTO.ExpertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Expert
{
    public class ExpertAddValidator:AbstractValidator<ExpertInfoAddDTO>
    {
        public ExpertAddValidator()
        {
            RuleFor(x => x.AddressInfoId).NotEmpty();

        }
    }
}
