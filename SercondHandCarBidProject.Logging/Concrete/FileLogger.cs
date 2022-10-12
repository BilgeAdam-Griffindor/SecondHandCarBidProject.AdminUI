using Newtonsoft.Json;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.LogModels;
using SercondHandCarBidProject.Logging.Nlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.Concrete
{
    public class FileLogger:ILoggerExtension
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public FileLogger()
        {
            LogConfig logConfig = new LogConfig();
        }
        public Task DataLog(LogModel data)
        {
            string message = null;
            try
            {
                message = JsonConvert.SerializeObject(data, Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       PreserveReferencesHandling = PreserveReferencesHandling.Objects
                   });
                Logger.Info(message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Hata Oluştu " + DateTime.Now + " " + message);
            }
            return Task.CompletedTask;
        }
    }
}
