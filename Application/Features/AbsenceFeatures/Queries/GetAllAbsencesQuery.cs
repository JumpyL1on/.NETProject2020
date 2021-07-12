using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AbsenceFeatures.Queries
{
    public class GetAllAbsencesQuery : IRequest<List<Absence>>
    {
        public class GetAllAbsencesQueryHandler : BaseHandler, IRequestHandler<GetAllAbsencesQuery, List<Absence>>
        {
            public GetAllAbsencesQueryHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<List<Absence>> Handle(GetAllAbsencesQuery request, CancellationToken cancellationToken)
            {
                return await ApplicationDbContext
                    .Set<Absence>()
                    .Include(absence => absence.ApplicationUser)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}