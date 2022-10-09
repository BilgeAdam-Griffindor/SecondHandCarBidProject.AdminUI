﻿using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.ApiService.Dto_s;
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
