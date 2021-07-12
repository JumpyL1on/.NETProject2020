using Domain.Common;
using Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistence.Context
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<SickDay> SickDays { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    }
}