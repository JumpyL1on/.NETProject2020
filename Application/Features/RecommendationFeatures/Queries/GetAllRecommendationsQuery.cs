using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RecommendationFeatures.Queries
{
    public class GetAllRecommendationsQuery : IRequest<List<Recommendation>>
    {
        public class GetAllRecommendationsQueryHandler : BaseHandler,
            IRequestHandler<GetAllRecommendationsQuery, List<Recommendation>>
        {
            public GetAllRecommendationsQueryHandler(DbContext applicationDbContext) : base(applicationDbContext)
            {
            }

            public async Task<List<Recommendation>> Handle(GetAllRecommendationsQuery request,
                CancellationToken cancellationToken)
            {
                return await ApplicationDbContext
                    .Set<Recommendation>()
                    .ToListAsync(cancellationToken);
            }
        }
    }
}