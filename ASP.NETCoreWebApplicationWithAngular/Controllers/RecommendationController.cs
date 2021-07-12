using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.RecommendationFeatures.Commands;
using Application.Features.RecommendationFeatures.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplicationWithAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : BaseApiController
    {
        public RecommendationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<List<Recommendation>> GetAll()
        {
            return await Mediator.Send(new GetAllRecommendationsQuery());
        }

        [HttpPut]
        public async Task Update(UpdateRecommendationCommand command)
        {
            await Mediator.Send(command);
        }
    }
}