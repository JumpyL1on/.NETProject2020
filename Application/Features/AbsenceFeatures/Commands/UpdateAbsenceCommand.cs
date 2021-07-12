using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AbsenceFeatures.Commands
{
    public class UpdateAbsenceCommand : IRequest<Absence>
    {
        public int Id { get; set; }
        public AbsenceType AbsenceType { get; set; }

        public class UpdateAbsenceCommandHandler : BaseHandler, IRequestHandler<UpdateAbsenceCommand, Absence>
        {
            public UpdateAbsenceCommandHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<Absence> Handle(UpdateAbsenceCommand command, CancellationToken cancellationToken)
            {
                Absence absence = null;
                switch (command.AbsenceType)
                {
                    case AbsenceType.SickLeave:
                    {
                        var sickLeave = await ApplicationDbContext.FindAsync<SickLeave>(command.Id);
                        sickLeave.Approve();
                        absence = sickLeave;
                        await ApplicationDbContext.SaveChangesAsync(cancellationToken);
                        break;
                    }
                    case AbsenceType.UnPaidVacation:
                    case AbsenceType.PaidVacation:
                    {
                        var vacation = await ApplicationDbContext.FindAsync<Vacation>(command.Id);
                        vacation.Approve();
                        absence = vacation;
                        await ApplicationDbContext.SaveChangesAsync(cancellationToken);
                        break;
                    }
                    case AbsenceType.SickDay:
                    case AbsenceType.ApprovedSickLeave:
                    case AbsenceType.ApprovedUnPaidVacation:
                    case AbsenceType.ApprovedPaidVacation:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return absence;
            }
        }
    }
}