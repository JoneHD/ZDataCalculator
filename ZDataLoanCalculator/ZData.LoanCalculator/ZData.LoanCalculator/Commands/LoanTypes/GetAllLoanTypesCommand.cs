using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Commands.Interface;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Models.Context;

namespace ZData.LoanCalculator.Commands.LoanTypes
{
    public class GetAllLoanTypesCommand
    {
        private readonly LoanCalculatorContext _context;
        private readonly IMapper _mapper;

        public GetAllLoanTypesCommand(LoanCalculatorContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> ExecuteAsync()
        {
            var result = _mapper.Map<ICollection<LoanTypeDto>>(
                        await _context.LoanType
                        .AsNoTracking().ToListAsync());
            return new OkObjectResult(result);
        }
    }
}
