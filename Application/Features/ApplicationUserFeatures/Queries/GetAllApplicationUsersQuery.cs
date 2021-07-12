using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ApplicationUserFeatures.Queries
{
    public class GetAllApplicationUsersQuery : IRequest<List<Resource>>
    {
        public class GetAllApplicationUsersQueryHandler : BaseHandler,
            IRequestHandler<GetAllApplicationUsersQuery, List<Resource>>
        {

            public GetAllApplicationUsersQueryHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<List<Resource>> Handle(GetAllApplicationUsersQuery request,
                CancellationToken cancellationToken)
            {
                var resources = new List<Resource> {new Resource()};
                await ApplicationDbContext.Set<ApplicationUser>()
                    .Where(u => u.UserName != "admin@gmail.com")
                    .ForEachAsync(u => resources[0].Data.Add(new Employee {Text = u.UserName, Value = u.Id}),
                        cancellationToken);
                return resources;
            }
        }
    }
}