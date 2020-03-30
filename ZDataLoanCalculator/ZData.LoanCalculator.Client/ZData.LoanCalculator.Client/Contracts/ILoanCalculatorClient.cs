using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZData.LoanCalculator.Common.Dtos;

namespace ZData.LoanCalculator.Client.Contracts
{
    public interface ILoanCalculatorClient
    {
        Task<ICollection<LoanTypeDto>> GetAllLoanTypes();

        Task<PaymentPlanDto> GeneratePaymentPlan(LoanPaymentPlanRequest request);
    }
}
