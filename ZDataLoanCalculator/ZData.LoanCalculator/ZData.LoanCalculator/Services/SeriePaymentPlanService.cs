using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Models.Context;
using ZData.LoanCalculator.Services.Interfaces;

namespace ZData.LoanCalculator.Services
{
    public class SeriePaymentPlanService : IPaymentPlanService
    {
        protected readonly LoanCalculatorContext _context;


        public SeriePaymentPlanService(LoanCalculatorContext context)
        {
            _context = context;
        }

        public async Task<PaymentPlanDto> GeneratePaymentPlan(LoanPaymentPlanRequest request)
        {
            var loanType = await _context.LoanType
                .FirstOrDefaultAsync(x => x.Id == request.LoanTypeId);

            if (loanType == null) throw new KeyNotFoundException($"LoanType with id: {request.LoanTypeId} not found.");

            var paymentPlan = new PaymentPlanDto
            {
                Payments = new List<PaymentDto>()
            };

            var numberOfPayments = request.Length * 12;
            var installment = request.Amount / numberOfPayments;

            var remainingDebt = request.Amount;
            var date = DateTimeOffset.UtcNow;

            for (int i = 0; i < numberOfPayments; i++)
            {
                var interest = (remainingDebt * (loanType.InterestRate / 100)) / 12;
                var toPay = installment + interest;

                if(i == numberOfPayments - 1)
                {
                    var lastPayment = remainingDebt + interest;
                    remainingDebt = 0;
                    var lastTerm = new PaymentDto
                    {
                        Date = date,
                        ToPay = lastPayment,
                        Installment = installment,
                        Interest = interest,
                        RemainingDebt = remainingDebt
                    };
                    paymentPlan.Payments.Add(lastTerm);
                }
                else
                {
                    remainingDebt -= installment;

                    var term = new PaymentDto
                    {
                        Date = date,
                        ToPay = toPay,
                        Interest = interest,
                        Installment = installment,
                        RemainingDebt = remainingDebt
                    };
                    paymentPlan.Payments.Add(term);
                }


                date = date.AddMonths(1);
            }

            return paymentPlan;
        }
    }
}
