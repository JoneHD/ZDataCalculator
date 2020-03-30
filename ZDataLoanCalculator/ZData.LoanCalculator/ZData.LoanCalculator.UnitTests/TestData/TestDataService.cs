using System;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Common.Enum;
using ZData.LoanCalculator.Models.Entities.LoanTypes;

namespace ZData.LoanCalculator.UnitTests.TestData
{
    internal static class TestDataService
    {

        internal static LoanType GetLoanType()
        {
            return new LoanType()
            {
                Name = "Test Loan",
                InterestRate = 20
            };
        }

        internal static LoanPaymentPlanRequest GetLoanPaymentPlanRequest(Guid loanTypeId)
        {
            return new LoanPaymentPlanRequest()
            {
                Amount = 400000,
                Length = 3,
                LoanTypeId = loanTypeId,
                PaymentScheme = PaymentScheme.SeriesLoan
            };
        }

    }
}
