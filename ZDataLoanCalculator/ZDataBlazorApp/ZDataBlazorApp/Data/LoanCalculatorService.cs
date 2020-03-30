using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZData.LoanCalculator.Client.Contracts;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Common.Enum;

namespace ZDataBlazorApp.Data
{
    public class LoanCalculatorService : ComponentBase
    {

        [Inject]
        private ILoanCalculatorClient _client { get; set; }

        protected decimal Amount { get; set; } = 400000;
        protected int Years { get; set; } = 3;

        protected PaymentPlanDto Curr_PaymentPlan{ get; set; }

        protected bool Hide_ValidationMessage_Amount { get; set; } = true;
        protected bool Hide_ValidationMessage_Years { get; set; } = true;

        public bool ValidateInput()
        {
            bool result = true;

            if (Amount >= 1000 && Amount <= 1000000000)
            {
                Hide_ValidationMessage_Amount = true;
            }
            else
            {
                result = false;
                Hide_ValidationMessage_Amount = false;
            }

            if (Years >= 1 && Years <= 50)
            {
                Hide_ValidationMessage_Years = true;
            }
            else
            {
                result = false;
                Hide_ValidationMessage_Years = false;
            }

            return result;
        }


        public string Get_Row_Color(int id)
        {

            if (id % 2 == 0)
            {
                return "#F5F5F5";
            }
            else
            {
                return "#A3CEDC";
            }
        }

        public async Task GetPaymentPlan()
        {
            if (ValidateInput())
            {
                var request = new LoanPaymentPlanRequest()
                {
                    Amount = Amount,
                    Length = Years,
                    LoanTypeId = Guid.Parse("05E6EB50-5DA8-4860-9E53-B9A6D5232E50"),
                    PaymentScheme = PaymentScheme.SeriesLoan
                };
               Curr_PaymentPlan = await _client.GeneratePaymentPlan(request);
            }
            else
            {
                Amount = 1000000;
                Years = 1;
            }

            StateHasChanged();
        }
    }
}
