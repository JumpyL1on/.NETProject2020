using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AbsenceFeatures.Commands
{
    public class DeleteAbsenceCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteAbsenceCommandHandler : BaseHandler, IRequestHandler<DeleteAbsenceCommand, Unit>
        {
            public DeleteAbsenceCommandHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<Unit> Handle(DeleteAbsenceCommand request, CancellationToken cancellationToken)
            {
                var absence = await ApplicationDbContext
                    .Set<Absence>()
                    .FindAsync(request.Id);
                ApplicationDbContext
                    .Set<Absence>()
                    .Remove(absence);
                await ApplicationDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}