using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZData.LoanCalculator.Client.Contracts;
using ZData.LoanCalculator.Client.Extensions;
using ZData.LoanCalculator.Common.Dtos;

namespace ZData.LoanCalculator.Client.Clients
{
    public class LoanCalculatorClient : ILoanCalculatorClient
    {
        private readonly HttpClient _client;

        public LoanCalculatorClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<PaymentPlanDto> GeneratePaymentPlan(LoanPaymentPlanRequest request)
         => await _client.PostJsonAsync<PaymentPlanDto>("/api/LoanCalculator/generateplan", request);

        public async Task<ICollection<LoanTypeDto>> GetAllLoanTypes()
            => await _client.GetJsonAsync<List<LoanTypeDto>>("/api/loantypes");


    }
}
