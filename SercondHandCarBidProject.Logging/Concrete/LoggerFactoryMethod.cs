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
    public class LoggerFactoryMethod: ILoggerFactoryMethod
    {
        IMongoLog mongolog;
        public LoggerFactoryMethod(IMongoLog _mongoLog)
        {
            mongolog = _mongoLog;
        }
        public enum LoggerType
        {
            MongoDatabaseLogger = 1,
            FileLogger = 2,
        }
        public async Task FactoryMethod(LoggerType logType, LogModel data)
        {
            ILoggerExtension log = null;
            switch (logType)
            {
                case LoggerType.MongoDatabaseLogger:
                    log = new MongoDatabaseLog(mongolog);
                    break;
                case LoggerType.FileLogger:
                    log = new FileLogger();
                    break;
                default:
                    break;
            }
            await log.DataLog(data);
        }
    }
}
