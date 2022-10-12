using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.ApiService.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DAL
{
    public class BaseDAL
    {
        BaseServices baseServices;
        public BaseDAL(BaseServices _baseServices)
        {
            baseServices = _baseServices;
        }

        public async Task<ResponseModel<T>> LoginAsync<T, TData>(TData postData)
        {
            var body = new StringContent(JsonConvert.SerializeObject(postData));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await baseServices.LoginAsync<T, TData>(postData);
            return response;
        }
        public async Task<ResponseModel<List<T>>> ListAll<T>(string route, string token)
        {
            var response = await baseServices.ListAll<T>(route, token);
            return response;
        }


        public async Task<ResponseModel<T>> GetByIdAsync<T>(object id, string route, string token)
        {
            var response = await baseServices.GetByIdAsync<T>(id, route, token);
            return response;

        }
        public async Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string queryString = "", int page = 1, int perPage = 100)
        {
            var response = await baseServices.GetByFilterAsync<T>(route, token, queryString, page, perPage);

            return response;
        }

        public async Task<ResponseModel<T>> SaveAsync<T>(T data, string name, string token)
        {
            var response = await baseServices.SaveAsync<T>(data, name, token);
            return response;
        }

        public async Task<bool> UpdateAsync<T>(T data, string name, string token)
        {
            var response = await baseServices.UpdateAsync(data, name, token);
            return response;
        }

        public async Task<bool> RemoveAsync<T>(object id, string route, string token)
        {
            var response = await baseServices.RemoveAsync<T>(id, route, token);
            return response;
        }

    }
}
