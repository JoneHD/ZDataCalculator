using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZData.LoanCalculator.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(
            this IServiceCollection services)
        {
            services.AddSwaggerDocument(configure => {
                configure.PostProcess = (document) => {
                    document.Info.Version = "v1";
                    document.Info.Title = "ZData LoanCalculator";
                    document.Info.Description = "ZData LoanCalculator API.";
                };
            });
        }
    }
}
