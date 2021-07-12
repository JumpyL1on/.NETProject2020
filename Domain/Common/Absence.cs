using System;
using Domain.Entities;

namespace Domain.Common
{
    public class Absence
    {
        public int Id { get; protected set; }
        public AbsenceType AbsenceType { get; protected set; }
        public string ApplicationUserId { get; protected set; }
        public ApplicationUser ApplicationUser { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }

        protected Absence()
        {
        }

        public Absence(AbsenceType absenceType, string applicationUserId, ApplicationUser applicationUser,
            DateTime start, DateTime end)
        {
            AbsenceType = absenceType;
            ApplicationUserId = applicationUserId;
            ApplicationUser = applicationUser;
            Start = start;
            End = end;
        }
    }
}