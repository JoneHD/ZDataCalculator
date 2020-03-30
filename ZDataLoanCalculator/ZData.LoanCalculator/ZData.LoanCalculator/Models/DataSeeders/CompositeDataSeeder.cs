using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Models.Context;

namespace ZData.LoanCalculator.Models.DataSeeders
{
    public static class CompositeDataSeeder
    {
        public static void SeedData(LoanCalculatorContext context)
        {
            LoanTypeDataSeeder.SeedData(context);
        }
    }
}
