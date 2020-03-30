using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZData.LoanCalculator.Common.Commands;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.IntegrationTests.Constants;
using ZData.LoanCalculator.Tests;

namespace ZData.LoanCalculator.IntegrationTests
{
    public class LoanTypeControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetLoanType_ReturnsLoanType_WhenLoanTypeExitsInTheDatabase()
        {
            //Arrange
            var CreatedLoanType = await CreateLoanTypeAsync(new CreateLoanTypeRequest()
            {
                Name = "Test Housing Loan",
                InterestRate = 3.5M
            });


            //Act
            var response = await TestClient.GetAsync(ApiRoutes.GetLoanType + CreatedLoanType.Id);


            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var loanType = await response.Content.ReadAsAsync<LoanTypeDto>();
            Assert.NotNull(loanType);
            Assert.Equal(CreatedLoanType.Id, loanType.Id);
        }


        [Fact]
        public async Task GetLoanType_WithoutAnyLoanTypes_ReturnsNotFound()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync(ApiRoutes.GetLoanType + "5247F2CF-29B1-4F0F-A5EF-07745097E4D5");

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
