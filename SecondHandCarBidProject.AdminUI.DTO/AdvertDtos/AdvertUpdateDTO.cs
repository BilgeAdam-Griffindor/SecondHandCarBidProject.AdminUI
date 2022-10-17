﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AdvertDtos
{
    public record AdvertUpdateDTO(Guid id, string AdvertTitle, string AdvertDescription, bool IsActive, DateTime CreatedDate, DateTime ModifiedDate, CarDetailAddSendDTO car)
    {
    }
}
