using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ZData.LoanCalculator.Models.Context;
using ZData.LoanCalculator.Services;
using ZData.LoanCalculator.UnitTests.TestData;

namespace ZData.LoanCalculator.UnitTests
{
    public class SeriePaymentPlanServiceTests
    {

        [Fact]
        public async void GeneratePlan_ReturnsListWithElements_WhenProvidingLoanTypeIdThatExist()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LoanCalculatorContext>()
                  .UseInMemoryDatabase(databaseName: "TestDB")
                  .Options;

            using (var context = new LoanCalculatorContext(options))
            {
                context.LoanType.Add(TestDataService.GetLoanType());
                context.SaveChanges();
            }

            //Act 
            //Assert
            // Run the test against one instance of the context
            using (var context = new LoanCalculatorContext(options))
            {                
                var service = new SeriePaymentPlanService(context);
                var loanTypeId = context.LoanType.FirstOrDefault().Id;
                var paymentPlan = await service.GeneratePaymentPlan(TestDataService.GetLoanPaymentPlanRequest(loanTypeId));
                Assert.NotEmpty(paymentPlan.Payments);
            }

           
        }

    }
}
