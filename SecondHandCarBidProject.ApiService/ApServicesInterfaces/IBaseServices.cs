using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.ApiService.ApServicesInterfaces
{
    public interface IBaseServices
    {
        public Task<ResponseModel<T>> LoginAsync<T, TData>(string loginUrl, TData postData);
        public Task<ResponseModel<List<T>>> ListAll<T>(string route, string token);
        public Task<ResponseModel<T>> GetByIdAsync<T>(object id, string route, string token);
        public Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string filterQueryString = "");
        public Task<ResponseModel<TResponse>> SaveAsync<TData, TResponse>(TData data, string name, string token);
        public Task<ResponseModel<TResponse>> UpdateAsync<TData, TResponse>(TData data, string name, string token);
        public Task<ResponseModel<T>> RemoveAsync<T>(object id, string route, string token);

    }
}
