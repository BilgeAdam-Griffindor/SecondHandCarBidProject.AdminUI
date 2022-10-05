using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.GUI.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
//using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace SecondHandCarBidProject.AdminUI.GUI.ApiServices
{
    public class BaseServices<T> where T : class
    {
        HttpClient _client;

        public BaseServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<ResponseModel<List<T>>> ListAll(string route, string token)
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<T>>>(route);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            return response;
        }

        public async Task<ResponseModel<T>> GetByIdAsync(object id, string route, string token)
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<T>>(route);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);

            return response;

        }

        public async Task<ResponseModel<T>> SaveAsync(T data, string name, string token)
        {
            var response = await _client.PostAsJsonAsync(name, data);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<ResponseModel<T>>();
            return responseBody;
        }

        public async Task<bool> UpdateAsync(T data, string name, string token)
        {
            var response = await _client.PutAsJsonAsync(name, data);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(object id,string route, string token)
        {
            var response = await _client.DeleteAsync(route);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
            return response.IsSuccessStatusCode;
        }
    }
}
