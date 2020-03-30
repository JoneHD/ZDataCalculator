using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Models.Context;
using ZData.LoanCalculator.Models.Entities.LoanTypes;

namespace ZData.LoanCalculator.Models.DataSeeders
{
    public static class LoanTypeDataSeeder
    {
        public static void SeedData(LoanCalculatorContext context)
        {
            var loanTypes = new[]
            {
                new LoanType{ Id = new Guid("05E6EB50-5DA8-4860-9E53-B9A6D5232E50"), Name = "Housing Loan", InterestRate = 3.5M},
                new LoanType{ Id = new Guid("5247F2CF-29B1-4F0F-A5EF-07745097E4D5"), Name = "Spending Loan", InterestRate = 16.5M}
            };

            foreach (var loanType in loanTypes)
            {
                if (!context.LoanType.Any(x => x.Id == loanType.Id))
                {
                    context.LoanType.Add(loanType);
                }
            }
            context.SaveChanges();
        }
    }
}
