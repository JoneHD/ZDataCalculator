using System;
using System.Collections.Generic;
using System.Text;
using ZData.LoanCalculator.Common.Enum;

namespace ZData.LoanCalculator.Common.Dtos
{
    public class LoanPaymentPlanRequest
    {
        public decimal Amount { get; set; }
        public int Length { get; set; }
        public Guid LoanTypeId { get; set; }
        public PaymentScheme PaymentScheme { get; set; }
    }
}
