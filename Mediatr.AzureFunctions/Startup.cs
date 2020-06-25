using FluentValidation;
using Mediatr.AzureFunctions.Domain;
using Mediatr.AzureFunctions.Domain.Behaviours;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Mediatr.AzureFunctions.Startup))]
namespace Mediatr.AzureFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(typeof(GetUserQueryHandler));
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            builder.Services.AddSingleton<IValidator<GetUserQuery>, GetUserQueryValidator>();

            builder.Services.AddSingleton<IHttpFunctionExecutor, HttpFunctionExecutor>();
        }
    }
}