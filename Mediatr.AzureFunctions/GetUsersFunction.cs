using Mediatr.AzureFunctions.Domain;
using Mediatr.AzureFunctions.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mediatr.AzureFunctions
{
    public class GetUsersFunction : BaseFunction<GetUserQuery, IEnumerable<User>>
    {
        public GetUsersFunction(IMediator mediator) : base(mediator)
        { }

        [FunctionName("GetUsersFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            GetUserQuery getUserQuery,
            ILogger log)
        {
            return await base.Run(getUserQuery);
        }
    }

}
