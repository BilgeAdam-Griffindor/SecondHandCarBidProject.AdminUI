using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.ApiService.ApiServices;
using SecondHandCarBidProject.ApiService.ApServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DAL.Interfaces
{
    public interface IBaseDAL
    {
        public Task<ResponseModel<TResponse>> LoginAsync<TResponse, TData>(string loginUrl, TData postData);

        public Task<ResponseModel<List<T>>> ListAll<T>(string route, string token);
        public Task<ResponseModel<T>> GetByIdAsync<T>(object id, string route, string token);
        public Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string queryString = "");
        public Task<ResponseModel<TResponse>> SaveAsync<TData, TResponse>(TData data, string route, string token);
        public Task<ResponseModel<TResponse>> UpdateAsync<TData, TResponse>(TData data, string route, string token);
        public Task<ResponseModel<T>> RemoveByFilterAsync<T>(string filterQueryString, string route, string token);
    }

}