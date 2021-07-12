using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.ApplicationUserFeatures.Queries;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplicationWithAngular.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationUserController : BaseApiController
    {
        public ApplicationUserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<List<Resource>> GetAll()
        {
            return await Mediator.Send(new GetAllApplicationUsersQuery());
        }
    }
}