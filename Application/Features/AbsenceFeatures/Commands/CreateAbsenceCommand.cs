using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AbsenceFeatures.Commands
{
    public class CreateAbsenceCommand : IRequest<Unit>
    {
        public AbsenceType AbsenceType { get; set; }
        public string ApplicationUserUserName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool? IsPaid { get; set; }

        public class CreateAbsenceCommandHandler : BaseHandler, IRequestHandler<CreateAbsenceCommand, Unit>
        {
            public CreateAbsenceCommandHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<Unit> Handle(CreateAbsenceCommand command, CancellationToken cancellationToken)
            {
                var user = await ApplicationDbContext
                    .Set<ApplicationUser>()
                    .FirstOrDefaultAsync(applicationUser => applicationUser.UserName == command.ApplicationUserUserName,
                        cancellationToken);
                switch (command.AbsenceType)
                {
                    case AbsenceType.SickDay:
                    {
                        var sickDay = new SickDay(user.Id, user, command.Start, command.End);
                        await ApplicationDbContext
                            .Set<SickDay>()
                            .AddAsync(sickDay, cancellationToken);
                        break;
                    }
                    case AbsenceType.SickLeave:
                    {
                        var sickLeave = new SickLeave(user.Id, user, command.Start, command.End);
                        await ApplicationDbContext
                            .Set<SickLeave>()
                            .AddAsync(sickLeave, cancellationToken);
                        break;
                    }
                    case AbsenceType.UnPaidVacation:
                    {
                        var vacation = new Vacation(user.Id, user, command.Start, command.End);
                        if (command.IsPaid.HasValue && command.IsPaid.Value)
                            vacation.Pay();
                        await ApplicationDbContext
                            .Set<Vacation>()
                            .AddAsync(vacation, cancellationToken);
                        break;
                    }
                    case AbsenceType.ApprovedSickLeave:
                    case AbsenceType.ApprovedUnPaidVacation:
                    case AbsenceType.PaidVacation:
                    case AbsenceType.ApprovedPaidVacation:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                await ApplicationDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}