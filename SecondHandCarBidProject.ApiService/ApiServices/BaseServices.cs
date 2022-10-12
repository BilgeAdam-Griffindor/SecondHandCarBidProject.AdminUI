using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.ApiService.ApiServices
{
    public class BaseServices
    {
        HttpClient _client;
        public BaseServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ResponseModel<T>> LoginAsync<T, TData>(TData postData)
        {
            var body = new StringContent(JsonConvert.SerializeObject(postData));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("Login/Authenticate", body);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ResponseModel<T>>(await response.Content.ReadAsStringAsync());
        }
        public async Task<ResponseModel<List<T>>> ListAll<T>(string route, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            var response = await _client.GetFromJsonAsync<ResponseModel<List<T>>>(route);
            return response;
        }

        public async Task<ResponseModel<T>> GetByIdAsync<T>(object id, string route, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            var response = await _client.GetFromJsonAsync<ResponseModel<T>>(route);
            return response;

        }
        public async Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string queryString = "", int page = 1, int perPage = 100)
        {
            string pageQueryString = "page=" + page + "&perPage=" + perPage;
            var fullQuery = queryString == "" ? pageQueryString : queryString + "&" + pageQueryString;

            var response = await _client.GetAsync(route + "?" + fullQuery);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ResponseModel<T>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ResponseModel<T>> SaveAsync<T>(T data, string name, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            var response = await _client.PostAsJsonAsync(name, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<ResponseModel<T>>();
            return responseBody;
        }

        public async Task<bool> UpdateAsync<T>(T data, string name, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            var response = await _client.PutAsJsonAsync(name, data);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync<T>(object id,string route, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            var response = await _client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }


    }
}
