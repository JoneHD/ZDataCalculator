using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Common.Enum;
using ZData.LoanCalculator.Services.Interfaces;

namespace ZData.LoanCalculator.Controllers.Api
{
    [Route("api/LoanCalculator")]
    public class LoanCalculatorController : Controller
    {
        private readonly Func<PaymentScheme, IPaymentPlanService> _paymentPlanService;
        public LoanCalculatorController(Func<PaymentScheme, IPaymentPlanService> paymentPlanService)
        {
            _paymentPlanService = paymentPlanService;
        }

        [HttpPost("generatePlan")]
        [ProducesResponseType(typeof(PaymentPlanDto), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [Produces("application/json")]
        public async Task<IActionResult> GeneratePaymentPlan([FromBody] LoanPaymentPlanRequest request)
        {
            var service = GetPaymentService(request.PaymentScheme);
            try
            {
                var result = await service.GeneratePaymentPlan(request);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private IPaymentPlanService GetPaymentService(PaymentScheme paymentScheme)
        {
            return _paymentPlanService(paymentScheme);
        }
    }
}
