using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions;
using SecondHandCarBidProject.ApiService.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;
using SercondHandCarBidProject.Logging.MongoContext;
using SercondHandCarBidProject.Logging.MongoContext.Concrete;
using SercondHandCarBidProject.Logging.Abstract;
using SercondHandCarBidProject.Logging.Concrete;
using SercondHandCarBidProject.Logging.LogModels;

namespace SecondHandCarBidProject.ApiService.HttpConfiguration
{
    public static class HttpServiceExtension
    {
       
        public static void AddHttpService(this IServiceCollection services, IConfiguration _Configuration)
        {

            services.Configure<MongoSettings>(_Configuration.GetSection("MongoSettings"));

            services.AddSingleton<IMongoLog<MongoLogModel>, MongoLog<MongoLogModel>>();
            services.AddScoped<ILogCatcher,LogCatcherMongolog>();
            services.AddScoped(typeof(ILoggerFactoryMethod<>), typeof(LoggerFactoryMethod<>));

            services.AddHttpClient<BaseServices>(opt =>
            {
                opt.BaseAddress = new Uri(_Configuration.GetSection("BaseUrl").Value);
            });
        }
    }
}
