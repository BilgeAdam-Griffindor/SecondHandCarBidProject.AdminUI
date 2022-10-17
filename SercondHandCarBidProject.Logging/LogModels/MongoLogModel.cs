using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SercondHandCarBidProject.Logging.Abstract;

namespace SercondHandCarBidProject.Logging.LogModels
{
    public class MongoLogModel: ILogEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Log_id")]
        public int LogId { get; set; }
        [BsonElement("LogType")]
        public string LogType { get; set; }
        [BsonElement("Exception")]
        public string Exception { get; set; }

        [BsonElement("created_date")]
        public DateTime CreatedDate { get; set; }
       
    }
}
