using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Vacation : Absence
    {
        protected Vacation()
        {
        }

        public Vacation(string applicationUserId, ApplicationUser applicationUser, DateTime start, DateTime end) : base(
            AbsenceType.UnPaidVacation, applicationUserId, applicationUser, start, end)
        {
        }

        public void Pay()
        {
            AbsenceType = AbsenceType.PaidVacation;
        }

        public void Approve()
        {
            AbsenceType = AbsenceType == AbsenceType.UnPaidVacation
                ? AbsenceType.ApprovedUnPaidVacation
                : AbsenceType.ApprovedPaidVacation;
        }
    }
}