using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZData.LoanCalculator.Commands.Interface;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Models.Context;

namespace ZData.LoanCalculator.Commands.LoanTypes
{
    public class GetLoanTypeCommand : IAsyncCommand<Guid>
    {
        private readonly LoanCalculatorContext _context;
        private readonly IMapper _mapper;

        public GetLoanTypeCommand(LoanCalculatorContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> ExecuteAsync(Guid id)
        {
            var loanType = await _context.LoanType.FirstOrDefaultAsync(x => x.Id == id);
            if (loanType == null)
            {
                return new NotFoundObjectResult($"LoanType with id {id} does not exists.");
            }
            else
            {
                var result = _mapper.Map<LoanTypeDto>(loanType);
                return new OkObjectResult(result);
            }


        }
    }
}
