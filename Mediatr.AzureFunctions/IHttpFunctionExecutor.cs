using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mediatr.AzureFunctions
{
    public interface IHttpFunctionExecutor
    {
        Task<IActionResult> ExecuteAsync(Func<Task<IActionResult>> func);
    }
}
