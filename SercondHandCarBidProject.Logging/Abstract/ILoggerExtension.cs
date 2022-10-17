using SercondHandCarBidProject.Logging.LogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.Abstract
{
    public interface ILoggerExtension<T> where T:class, ILogEntity
    {
        Task DataLog(T data);

    }
}
