﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.ActionAuthDtos
{
    public record ActionAuthTypeUpdateDTO(int id, string AuthorizationName, bool IsActive)
    {
    }
}
