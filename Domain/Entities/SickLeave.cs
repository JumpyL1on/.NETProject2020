using System;
using Domain.Common;

namespace Domain.Entities
{
    public class SickLeave : Absence
    {
        protected SickLeave()
        {
        }

        public SickLeave(string applicationUserId, ApplicationUser applicationUser,
            DateTime start, DateTime end) : base(AbsenceType.SickLeave, applicationUserId, applicationUser, start, end)
        {
        }

        public void Approve()
        {
            AbsenceType = AbsenceType.ApprovedSickLeave;
        }
    }
}