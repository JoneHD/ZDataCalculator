using Microsoft.Extensions.DependencyInjection;
using System;
using ZData.LoanCalculator.Commands.LoanTypes;

namespace ZData.LoanCalculator.Configuration
{
    public static class CommandConfiguration
    {

        private static IServiceCollection AddCommand<TService, TImplementation>(
            this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddScoped<TService, TImplementation>();
            services.AddScoped(x => new Lazy<TService>(x.GetRequiredService<TService>));
            return services;
        }

        public static IServiceCollection AddCommands(
            this IServiceCollection services)
        {
            services.AddCommand<AddLoanTypeCommand, AddLoanTypeCommand>();
            services.AddCommand<GetLoanTypeCommand, GetLoanTypeCommand>();
            services.AddCommand<GetAllLoanTypesCommand, GetAllLoanTypesCommand>();
            return services;
        }
    }
}
