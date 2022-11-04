using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos
{
    public class PageAuthTypeClassDto
    {
        [JsonProperty("id")]
        public Int16 id { get; set; }
        [JsonProperty("authorizationName")]
        public string authorizationName { get; set; }
    }
}
