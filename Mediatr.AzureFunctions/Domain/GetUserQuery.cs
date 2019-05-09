using System.Collections.Generic;
using Mediatr.AzureFunctions.Models;
using MediatR;

namespace Mediatr.AzureFunctions.Domain
{
    public class GetUserQuery : IRequest<IEnumerable<User>>
    {
        public string Name { get; set; }
    }
}