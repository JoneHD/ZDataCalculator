using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZData.LoanCalculator.Commands.LoanTypes;
using ZData.LoanCalculator.Common.Commands;
using ZData.LoanCalculator.Common.Dtos;

namespace ZData.LoanCalculator.Controllers.Api
{
    [Route("api/LoanType")]
    public class LoanTypeController : Controller
    {
        private readonly Lazy<AddLoanTypeCommand> _addLoanTypeCommand;
        private readonly Lazy<GetLoanTypeCommand> _getLoanTypeCommand;
        private readonly Lazy<GetAllLoanTypesCommand> _getAllLoanTypeCommand;

        public LoanTypeController(
            Lazy<AddLoanTypeCommand> addLoanTypeCommand,
            Lazy<GetLoanTypeCommand> getLoanTypeCommand,
            Lazy<GetAllLoanTypesCommand> getAllLoanTypeCommand)
        {
            _addLoanTypeCommand = addLoanTypeCommand;
            _getLoanTypeCommand = getLoanTypeCommand;
            _getAllLoanTypeCommand = getAllLoanTypeCommand;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(LoanTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> AddLoanType([FromBody] CreateLoanTypeRequest request)
         => await _addLoanTypeCommand.Value.ExecuteAsync(ModelState, request);

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LoanTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetLoanType(Guid id)
             => await _getLoanTypeCommand.Value.ExecuteAsync(id);


        [HttpGet("")]
        [ProducesResponseType(typeof(ICollection<LoanTypeDto>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllLoanTypes()
            => await _getAllLoanTypeCommand.Value.ExecuteAsync();

    }
}
