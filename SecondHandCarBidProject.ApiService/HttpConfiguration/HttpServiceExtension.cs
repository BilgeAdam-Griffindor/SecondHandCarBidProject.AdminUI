using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions;
using SecondHandCarBidProject.ApiService.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.ApiService.HttpConfiguration
{
    public static class HttpServiceExtension
    {
        private static IConfiguration _Configuration;
        public static void Configure(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
        public static void AddHttpService(this IServiceCollection services)
        {
            
            services.AddHttpClient<BidApiServices>(opt =>
            {
                opt.BaseAddress = new Uri(_Configuration.GetSection("ApiURL").Value);
            });
            //builder.Services.AddHttpClient<BaseServices>(opt =>
            //{
            //    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            //});
        }
    }
}
