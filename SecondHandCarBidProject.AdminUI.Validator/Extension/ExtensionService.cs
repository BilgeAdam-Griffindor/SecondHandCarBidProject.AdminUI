using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHandCarBidProject.AdminUI.Validator.PageAuthType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator.Extension
{
    public static class ExtensionService
    {
        public static void AddExtensionService(this IServiceCollection services, IConfiguration _Configuration)
        {
            services.AddValidatorsFromAssemblyContaining<PageAuthTypeAddValidator>();
        }
    }
}
