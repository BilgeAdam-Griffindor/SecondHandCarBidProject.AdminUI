using NLog;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.LogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.Concrete
{
    public class LogCatcherMongolog:ILogCatcher 
    {
        MongoLogModel LogModel;
        ILoggerFactoryMethod<MongoLogModel> loggerFactoryMethod;
        public LogCatcherMongolog(ILoggerFactoryMethod<MongoLogModel> _loggerFactoryMethod)
        {
            LogModel= new MongoLogModel();
            loggerFactoryMethod= _loggerFactoryMethod;
        }
        
        public  Task WriteLogWarning(Exception ex)
        {
            LogModel.Exception = ex.Message;
            LogModel.CreatedDate = DateTime.UtcNow;
            LogModel.LogType =(int)LogLevel.Type.Warning ;
            loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, LogModel);
            return Task.CompletedTask;
        }
        public Task WriteLogInfo(Exception ex)
        {
            LogModel.Exception = ex.Message;
            LogModel.CreatedDate = DateTime.UtcNow;
            LogModel.LogType = (int)LogLevel.Type.Info;
            loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, LogModel);
            return Task.CompletedTask;
        }
        public Task WriteLogDebug(Exception ex)
        {
            LogModel.Exception = ex.Message;
            LogModel.CreatedDate = DateTime.UtcNow;
            LogModel.LogType = (int)LogLevel.Type.Debug;
            loggerFactoryMethod.FactoryMethod(LoggerFactoryMethod<MongoLogModel>.LoggerType.MongoDatabaseLogger, LogModel);
            return Task.CompletedTask;
        }

    }
}
