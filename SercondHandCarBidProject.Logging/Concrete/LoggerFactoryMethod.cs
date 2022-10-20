using Microsoft.Extensions.Logging;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.Concrete
{
    public class LoggerFactoryMethod<T>: ILoggerFactoryMethod<T> where T:class, ILogEntity
    {
        IMongoLog<T> mongolog;
        public LoggerFactoryMethod()
        {

        }
       
        public LoggerFactoryMethod(IMongoLog<T> _mongoLog)
        {
            mongolog = _mongoLog;
        }
        public enum LoggerType
        {
            MongoDatabaseLogger = 1,
            FileLogger = 2,
        }
        public async Task FactoryMethod(LoggerType logType, T data)
        {
            ILoggerExtension<T> log = null;
            switch (logType)
            {
                case LoggerType.MongoDatabaseLogger:
                    log = new MongoDatabaseLog<T>(mongolog);
                    break;
                case LoggerType.FileLogger:
                    log = new FileLogger<T>();
                    break;
                default:
                    log = new FileLogger<T>();
                    break;
            }
            await log.DataLog(data);
        }
    }
}
