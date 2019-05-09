using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Mediatr.AzureFunctions
{
    public abstract class BaseFunction<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IMediator _mediator;

        protected BaseFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> Run(TRequest request)
        {
            try
            {
                var users = await _mediator.Send(request);

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