using Microsoft.Extensions.Logging;
using SercondHandCarBidProject.Logging.LogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  SercondHandCarBidProject.Logging.Concrete;

namespace SercondHandCarBidProject.Logging.Abstract
{
    public interface ILoggerFactoryMethod<T> where T:class ,ILogEntity
    {
        Task FactoryMethod(LoggerFactoryMethod<T>.LoggerType logType, T data);
    }
}
