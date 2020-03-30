using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZData.LoanCalculator.Tests;
using System.Net.Http;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Common.Commands;
using ZData.LoanCalculator.Common.Enum;
using Xunit;
using ZData.LoanCalculator.IntegrationTests.Constants;

namespace ZData.LoanCalculator.IntegrationTests
{
    public class LoanCalculatorControllerTests : IntegrationTest
    {
        //Denne testen feiler i LoanCalculatorController når den skal utføre GetPaymentService(PaymentScheme paymentScheme). Sikkert enkelt å fikse, men finner ikke ut av det.
        [Fact]
        public async Task GeneratePlan_WithValidLoanRequest_ReturnsListWithElements()
        {
            //Arrange
            var LoanType = await CreateLoanTypeAsync(new CreateLoanTypeRequest()
            {
                Name = "Test Housing Loan",
                InterestRate = 3.5M
            });

            var request = new LoanPaymentPlanRequest()
            {
                Amount = 400000,
                Length = 3,
                LoanTypeId = LoanType.Id,
                PaymentScheme = PaymentScheme.SeriesLoan
            };

            //Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.GeneratePlan, request);
            

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK,response.StatusCode);
            var paymentPlan = await response.Content.ReadAsAsync<PaymentPlanDto>();
            Assert.NotEmpty(paymentPlan.Payments);


        }
    }
}
