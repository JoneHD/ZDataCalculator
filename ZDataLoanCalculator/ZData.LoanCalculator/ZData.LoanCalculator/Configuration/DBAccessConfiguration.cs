using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Models.Context;

namespace ZData.LoanCalculator.Configuration
{
    public static class DBAccessConfiguration
    {
        public static void ConfigureDbAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LoanCalculatorContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(nameof(LoanCalculatorContext))));

        }
    }
}
