using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mediatr.AzureFunctions.Models;
using MediatR;

namespace Mediatr.AzureFunctions.Domain
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<User>>
    {
        public Task<IEnumerable<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var name = request.Name;

            var user = new User { Name = name };

            var result = new[] { user }
                .AsEnumerable();

            return Task.FromResult(result);
        }
    }
}