using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Common.Dtos;

namespace ZData.LoanCalculator.Services.Interfaces
{
    public interface IPaymentPlanService
    {
        Task<PaymentPlanDto> GeneratePaymentPlan(LoanPaymentPlanRequest request);
    }
}
