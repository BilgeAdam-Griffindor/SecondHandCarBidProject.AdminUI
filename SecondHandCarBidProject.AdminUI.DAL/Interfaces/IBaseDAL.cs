using SecondHandCarBidProject.AdminUI.DTO;
using SecondHandCarBidProject.ApiService.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.DAL.Interfaces
{
    public interface IBaseDAL
    {
            public Task<ResponseModel<T>> LoginAsync<T, TData>(string loginUrl, TData postData);
            public Task<ResponseModel<List<T>>> ListAll<T>(string route, string token);
            public Task<ResponseModel<T>> GetByIdAsync<T>(object id, string route, string token);
            public Task<ResponseModel<T>> GetByFilterAsync<T>(string route, string token, string filterQueryString = "");
            public Task<ResponseModel<T>> SaveAsync<T>(T data, string route, string token);
            public Task<ResponseModel<T>> UpdateAsync<T>(T data, string route, string token);
            public Task<ResponseModel<T>> RemoveAsync<T>(object id, string route, string token);

    }

}