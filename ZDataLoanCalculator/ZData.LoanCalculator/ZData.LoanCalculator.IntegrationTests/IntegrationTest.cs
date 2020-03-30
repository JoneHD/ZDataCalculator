using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZData.LoanCalculator.Common.Commands;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Configuration;
using ZData.LoanCalculator.IntegrationTests.Constants;
using ZData.LoanCalculator.Models.Context;
using ZData.LoanCalculator.Services;
using ZData.LoanCalculator.Services.Interfaces;

namespace ZData.LoanCalculator.Tests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var context = services.FirstOrDefault(x => x.ServiceType == (typeof(LoanCalculatorContext)));
                        if (context != null) services.Remove(context);

                        services.AddDbContext<LoanCalculatorContext>(options =>
                        {
                            options.UseInMemoryDatabase(databaseName: "TestDB");
                        });

                        services.ConfigurePaymentPlanServices();
                    });
                });

            TestClient = appFactory.CreateClient();
        }


        protected async Task<LoanTypeDto> CreateLoanTypeAsync(CreateLoanTypeRequest request)
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.CreateLoanType, request);
            return await response.Content.ReadAsAsync<LoanTypeDto>(); 
        }


    }
}
