using Microsoft.EntityFrameworkCore;

namespace Application.Features
{
    public class BaseHandler
    {
        protected DbContext ApplicationDbContext { get; }

        protected BaseHandler()
        {
        }

        protected BaseHandler(DbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
    }
}