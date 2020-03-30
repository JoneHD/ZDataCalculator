using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZData.LoanCalculator.Commands.Interface
{
    public interface IAsyncModelStateCommand
    {
        Task<IActionResult> ExecuteAsync(ModelStateDictionary modelState);
    }

    public interface IAsyncModelStateCommand<T>
    {
        Task<IActionResult> ExecuteAsync(ModelStateDictionary modelState, T parameter);
    }
}
