using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.Validation;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class ResponseModel<T>
    {
        
        [JsonProperty("data")]
        public T Data { get; set; }     
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("errors")]
        public List<string>? Errors { get; set; }
    }
}
