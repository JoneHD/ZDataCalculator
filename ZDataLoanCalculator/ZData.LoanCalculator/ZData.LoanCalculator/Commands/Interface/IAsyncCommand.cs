using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZData.LoanCalculator.Commands.Interface
{
    public interface IAsyncCommand
    {
        Task<IActionResult> ExecuteAsync();
    }

    public interface IAsyncCommand<T>
    {
        Task<IActionResult> ExecuteAsync(T parameter);
    }
}
