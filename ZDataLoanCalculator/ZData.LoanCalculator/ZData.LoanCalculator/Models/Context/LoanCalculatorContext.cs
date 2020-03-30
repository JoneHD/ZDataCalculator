using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Models.Entities;
using ZData.LoanCalculator.Models.Entities.LoanTypes;

namespace ZData.LoanCalculator.Models.Context
{
    public class LoanCalculatorContext : DbContext
    {
        public LoanCalculatorContext(DbContextOptions<LoanCalculatorContext> options) : base(options)
        {
        }

        private bool _isDisposed;

        public virtual DbSet<LoanType> LoanType { get; set; }

        public override void Dispose()
            {
                if (!_isDisposed)
                {
                    _isDisposed = true;
                }
                base.Dispose();
            }
    }        

}
