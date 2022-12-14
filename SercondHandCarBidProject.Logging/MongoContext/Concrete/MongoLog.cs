using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.MongoContext.Concrete
{
    public class MongoLog<T> : IMongoLog<T> where T:class
    {

        IMongoCollection<T> _mongoLog;
        public MongoLog(IOptions<MongoSettings> MongoSettings)
        {
            
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(mongoSettings);
            var logForMongoDB = client.GetDatabase(MongoSettings.Value.DatabaseName);
            _mongoLog = logForMongoDB.GetCollection<T>(MongoSettings.Value.SecondHandCarAdminLogCollection);
        }
        public async Task<bool> AddLogToMongo(T log)
        {
            try
            {
                await _mongoLog.InsertOneAsync(log);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
