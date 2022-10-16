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
    /// <summary>
    /// This class add log data to mongodb
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoDatabaseLog<T>:ILoggerExtension<T> where T : class, ILogEntity
    {
        IMongoLog<T> mongoLog;

        public MongoDatabaseLog(IMongoLog<T> _mongoLog)
        {
            mongoLog = _mongoLog;
        }
        /// <summary>
        /// This method takes generic paramater as a T type data. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task DataLog(T data)
        {
            await mongoLog.AddLogToMongo(data);
           
        }
    }
}
