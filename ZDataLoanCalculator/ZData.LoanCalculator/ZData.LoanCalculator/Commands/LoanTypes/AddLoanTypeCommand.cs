using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Commands.Interface;
using ZData.LoanCalculator.Common.Commands;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Models.Context;
using ZData.LoanCalculator.Models.Entities.LoanTypes;

namespace ZData.LoanCalculator.Commands.LoanTypes
{
    public class AddLoanTypeCommand : IAsyncModelStateCommand<CreateLoanTypeRequest>
    {
        private readonly LoanCalculatorContext _context;
        private readonly IMapper _mapper;

        public AddLoanTypeCommand(IMapper mapper, LoanCalculatorContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IActionResult> ExecuteAsync(ModelStateDictionary modelState, CreateLoanTypeRequest request)
        {
            if (!modelState.IsValid) { return new BadRequestObjectResult(modelState);}

            var newLoanType = _context.LoanType.FirstOrDefault(x => x.Name == request.Name);

            if(newLoanType != null) 
            { 
                return new BadRequestObjectResult($"LoanType with name {request.Name} already exists.");
            }
            else
            {
                newLoanType = new LoanType()
                {
                    Name = request.Name,
                    InterestRate = request.InterestRate
                };
                await _context.AddAsync(newLoanType);
                await _context.SaveChangesAsync();

                var result = _mapper.Map<LoanTypeDto>(newLoanType);

                return new OkObjectResult(result);
            }
        }
    }
}
