using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.LoanCalculator.Common.Dtos
{
    public class LoanTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal InterestRate { get; set; }
    }
}
