using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AbsenceFeatures.Queries
{
    public class GetApprovableAbsencesQuery : IRequest<List<Absence>>
    {
        public class GetApprovableAbsencesQueryHandler : BaseHandler,
            IRequestHandler<GetApprovableAbsencesQuery, List<Absence>>
        {
            public GetApprovableAbsencesQueryHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<List<Absence>> Handle(GetApprovableAbsencesQuery request,
                CancellationToken cancellationToken)
            {
                return await ApplicationDbContext
                    .Set<Absence>()
                    .Include(absence => absence.ApplicationUser)
                    .Where(absence => absence.AbsenceType == AbsenceType.SickLeave ||
                                      absence.AbsenceType == AbsenceType.UnPaidVacation ||
                                      absence.AbsenceType == AbsenceType.PaidVacation)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}