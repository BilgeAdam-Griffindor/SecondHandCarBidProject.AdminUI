using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO.BidDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.ApiService.ApiServices
{
    public class BidApiServices
    {
        HttpClient _client;
        public BidApiServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> BiddAddAsync(BidAddDto bidAddDto)
        {
            var body = new StringContent(JsonConvert.SerializeObject(bidAddDto));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // WARNING: "Api/Url"  is formal URL. When Api service be ready  Url will change
            var response = await _client.PostAsync("Api/Url", body);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                bool.TryParse(content, out bool result);
                return result;
            }

            return false;
        }
    }
}
