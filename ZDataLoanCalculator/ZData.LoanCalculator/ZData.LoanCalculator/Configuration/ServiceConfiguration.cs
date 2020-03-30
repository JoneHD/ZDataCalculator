using Microsoft.Extensions.DependencyInjection;
using System;
using ZData.LoanCalculator.Common.Enum;
using ZData.LoanCalculator.Services;
using ZData.LoanCalculator.Services.Interfaces;

namespace ZData.LoanCalculator.Configuration
{
    public static class ServiceConfiguration
    {

        public static void ConfigurePaymentPlanServices(this IServiceCollection services)
        {
            services.AddSingleton<SeriePaymentPlanService>();

            services.AddTransient<Func<PaymentScheme, IPaymentPlanService>>
                (serviceProvider => key =>
                    {
                        switch (key)
                        {
                            case PaymentScheme.SeriesLoan:
                                return serviceProvider.GetService<SeriePaymentPlanService>();
                            default:
                                return null;
                        }
                    }
                );
        }
    }
}
