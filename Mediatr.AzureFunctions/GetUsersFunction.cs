using FluentValidation;
using Mediatr.AzureFunctions.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Mediatr.AzureFunctions
{
    public class GetUsersFunction
    {
        private readonly IMediator _mediator;
        private readonly IHttpFunctionExecutor _httpFunctionExecutor;

        public GetUsersFunction(IMediator mediator, IHttpFunctionExecutor httpFunctionExecutor)
        {
            _mediator = mediator;
            _httpFunctionExecutor = httpFunctionExecutor;
        }

        [FunctionName("GetUsersFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            GetUserQuery getUserQuery,
            ILogger log)
        {
            return await _httpFunctionExecutor.ExecuteAsync(async () =>
            {
                var users = await _mediator.Send(getUserQuery);
                return new OkObjectResult(users);
            });
        }
    }
}
