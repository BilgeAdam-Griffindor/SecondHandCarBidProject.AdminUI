using SercondHandCarBidProject.Logging.LogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.MongoContext.Abstract
{
    public interface IMongoLog<T> where T : class
    {
        Task<bool> AddLogToMongo(T log);
        
    }
}
