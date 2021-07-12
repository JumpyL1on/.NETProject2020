using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RecommendationFeatures.Commands
{
    public class UpdateRecommendationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public class UpdateRecommendationCommandHandler : BaseHandler,
            IRequestHandler<UpdateRecommendationCommand, Unit>
        {
            public async Task<Unit> Handle(UpdateRecommendationCommand command,
                CancellationToken cancellationToken)
            {
                var recommendation = await ApplicationDbContext.FindAsync<Recommendation>(command.Id);
                recommendation.Update(command.Content);
                await ApplicationDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}