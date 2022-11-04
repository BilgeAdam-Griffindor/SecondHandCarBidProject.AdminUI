using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class ResponseModelNew<T>
    {
        [JsonProperty("data")]
        //[JsonIgnore]
        public T Data { get; private set; }
       
        [JsonProperty("isSuccess")]
        public bool isSuccess { get; set; }
        [JsonProperty("errors")]
        public List<string>? errors { get; set; }
        
    }
}
