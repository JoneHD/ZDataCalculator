using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.LoanCalculator.Common.Commands
{
    public class CreateLoanTypeRequest
    {
        public string Name { get; set; }
        public decimal InterestRate { get; set; }

    }
}
