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
    public class MongoDatabaseLog:ILoggerExtension
    {
        IMongoLog mongoLog;

        public MongoDatabaseLog(IMongoLog _mongoLog)
        {
            mongoLog = _mongoLog;
        }
        public async Task DataLog(LogModel data)
        {
            await mongoLog.AddLogToMongo(data);
           
        }
    }
}
