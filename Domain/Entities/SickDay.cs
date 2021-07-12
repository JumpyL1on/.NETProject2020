using System;
using Domain.Common;

namespace Domain.Entities
{
    public class SickDay : Absence
    {
        protected SickDay()
        {
        }

        public SickDay(string applicationUserId, ApplicationUser applicationUser, DateTime start, DateTime end) : base(
            AbsenceType.SickDay, applicationUserId, applicationUser, start, end)
        {
            End = end.AddDays(1);
        }
    }
}