﻿using Newtonsoft.Json;
using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.AdminUI.DTO.Validation;
using SecondHandCarBidProject.ApiService.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DAL.Concrete
{
    public class BaseDAL
    {
        BaseServices baseServices;
        public BaseDAL(BaseServices _baseServices)
        {
            baseServices = _baseServices;
        }

        public async Task<ResponseModel<TResponse>> LoginAsync<TResponse, TData>(string loginUrl,TData postData)
        {
            var body = new StringContent(JsonConvert.SerializeObject(postData));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await baseServices.LoginAsync<TResponse, TData>(loginUrl,postData);
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
        public async Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string queryString = "")
        {
            var response = await baseServices.GetByFilterAsync<T>(route, token, queryString);
            return response;
        }

        public async Task<ResponseModel<TResponse>> SaveAsync<TData, TResponse>(TData data, string route, string token)
        {
            var response = await baseServices.SaveAsync<TData, TResponse>(data, route, token);
            return response;
        }

        public async Task<ResponseModel<TResponse>> UpdateAsync<TData, TResponse>(TData data, string route, string token)
        {
            var response = await baseServices.UpdateAsync<TData, TResponse>(data, route, token);
            return response;
        }

        public async Task<ResponseModel<T>> RemoveAsync<T>(object id, string route, string token)
        {
            var response = await baseServices.RemoveAsync<T>(id, route, token);
            return response;
        }

    }
}
