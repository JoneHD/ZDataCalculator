using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.LoanCalculator.Common.Dtos
{
    public class PaymentDto
    {
        public DateTimeOffset Date { get; set; }
        public decimal ToPay { get; set; }
        public decimal Installment { get; set; }
        public decimal Interest { get; set; }
        public decimal RemainingDebt { get; set; }
    }
}
