using SercondHandCarBidProject.Logging.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SercondHandCarBidProject.Logging.LogModels
{
    public class FileLogModel:ILogEntity
    {
        public string Exception { get; set; }
        public string LogLevel { get; set; }
        public string LogType { get; set; }
    }
}
