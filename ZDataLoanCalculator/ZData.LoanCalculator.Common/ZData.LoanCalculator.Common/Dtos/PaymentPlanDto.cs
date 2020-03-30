using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.LoanCalculator.Common.Dtos
{
    public class PaymentPlanDto
    {
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}
