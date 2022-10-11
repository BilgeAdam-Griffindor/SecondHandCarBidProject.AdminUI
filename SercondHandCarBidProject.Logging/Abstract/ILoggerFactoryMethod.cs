using SercondHandCarBidProject.Logging.LogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SercondHandCarBidProject.Logging.Concrete.LoggerFactoryMethod;

namespace SercondHandCarBidProject.Logging.Abstract
{
    public interface ILoggerFactoryMethod
    {
        Task FactoryMethod(LoggerType logType, LogModel data);
    }
}
