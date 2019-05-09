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

        public GetUsersFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("GetUsersFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            GetUserQuery getUserQuery,
            ILogger log)
        {
            try
            {
                var users = await _mediator.Send(getUserQuery);
                return new OkObjectResult(users);
            }
            catch (ValidationException validationException)
            {
                var result = new
                {
                    message = "Validation failed.",
                    errors = validationException.Errors.Select(x => new
                    {

                        x.PropertyName,
                        x.ErrorMessage,
                        x.ErrorCode
                    })
                };

                return new BadRequestObjectResult(result);
            }
        }
    }
}
