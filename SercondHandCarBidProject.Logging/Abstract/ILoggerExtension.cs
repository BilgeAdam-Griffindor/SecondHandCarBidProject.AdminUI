﻿using SercondHandCarBidProject.Logging.LogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.Abstract
{
    public interface ILoggerExtension
    {
        Task DataLog(LogModel data);

    }
}
