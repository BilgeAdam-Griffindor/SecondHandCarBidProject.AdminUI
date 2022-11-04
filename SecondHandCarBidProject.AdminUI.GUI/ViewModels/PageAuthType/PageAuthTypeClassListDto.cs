using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO.AuthorizationDtos;

namespace SecondHandCarBidProject.AdminUI.GUI.ViewModels.PageAuthType
{
    public class PageAuthTypeClassListDto
    {
        
        [JsonProperty("pageAuthTypeDtos")]
        public List<PageAuthTypeClassDto> pageAuthTypeClassDto { get; set; }
        [JsonProperty("maxPages")]
        public int maxPages { get; set; }
    }
}
