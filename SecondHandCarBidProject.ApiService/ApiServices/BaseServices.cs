using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.Validation;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
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
    public class BaseServices : IBaseServices
    {
        HttpClient _client;
        public BaseServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ResponseModel<T>> LoginAsync<T, TData>(string loginUrl, TData postData)
        {
            var body = new StringContent(JsonConvert.SerializeObject(postData));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync(loginUrl, body);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ResponseModel<T>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ResponseModel<List<T>>> ListAll<T>(string route, string token)
        {
            ResponseModel<List<T>> response = new ResponseModel<List<T>>();

            if (String.IsNullOrEmpty(token))
            {
                response.IsSuccess = false;
                response.statusCode = StatusCode.Unauthorized;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                response = await _client.GetFromJsonAsync<ResponseModel<List<T>>>(route);
                response.IsSuccess = true;
            }
            return response;
        }

        public async Task<ResponseModel<T>> GetByIdAsync<T>(object id, string route, string token)
        {
            ResponseModel<T> response = new ResponseModel<T>();
            if (String.IsNullOrEmpty(token))
            {
                response.IsSuccess = false;
                response.statusCode = StatusCode.Unauthorized;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                response = await _client.GetFromJsonAsync<ResponseModel<T>>(route);
                response.IsSuccess = true;
            }
            return response;

        }

        public async Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string filterQueryString = "")
        {
            if (!string.IsNullOrEmpty(filterQueryString))
                route += "?" + filterQueryString;

            ResponseModel<T> response = new ResponseModel<T>();

            if (String.IsNullOrEmpty(token))
            {
                response.IsSuccess = false;
                response.statusCode = StatusCode.Unauthorized;
                return response;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                var _response = await _client.GetAsync(route);
                if (!_response.IsSuccessStatusCode)
                {
                    return null;
                }
                return JsonConvert.DeserializeObject<ResponseModel<T>>(await _response.Content.ReadAsStringAsync());
            }
        }

        public async Task<ResponseModel<TResponse>> SaveAsync<TData,TResponse>(TData data, string route, string token)
        {
            ResponseModel<TResponse> response = new ResponseModel<TResponse>();

            if (String.IsNullOrEmpty(token))
            {
                response.IsSuccess = false;
                response.statusCode = StatusCode.Unauthorized;
                return response;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                var _response = await _client.PostAsJsonAsync(route, data);
                if (!_response.IsSuccessStatusCode)
                {
                    response.IsSuccess = false;
                    response.statusCode = (StatusCode)_response.StatusCode;
                    return response;
                }
                response = await _response.Content.ReadFromJsonAsync<ResponseModel<TResponse>>();
                return response;
            }
        }

        public async Task<ResponseModel<TResponse>> UpdateAsync<TData, TResponse>(TData data, string route, string token)
        {
            ResponseModel<TResponse> responseModel = new ResponseModel<TResponse>();
            if (String.IsNullOrEmpty(token))
            {
                responseModel.IsSuccess = false;
                responseModel.statusCode = StatusCode.Unauthorized;
                return responseModel;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                var _response = await _client.PutAsJsonAsync(route, data);
                responseModel.IsSuccess = _response.IsSuccessStatusCode;
                return responseModel;
            }
        }

        public async Task<ResponseModel<T>> RemoveAsync<T>(object id, string route, string token)
        {
            ResponseModel<T> responseModel = new ResponseModel<T>();
            if (String.IsNullOrEmpty(token))
            {
                responseModel.IsSuccess = false;
                responseModel.statusCode = StatusCode.Unauthorized;
                return responseModel;
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
                var _response = await _client.DeleteAsync(route);
                responseModel.IsSuccess = _response.IsSuccessStatusCode;
                return responseModel;
            }
        }


    }
}
