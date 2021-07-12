using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.AbsenceFeatures.Commands;
using Application.Features.AbsenceFeatures.Queries;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace ASP.NETCoreWebApplicationWithAngular.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AbsenceController : BaseApiController
    {
        public AbsenceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<List<Absence>> Get()
        {
            return await Mediator.Send(new GetAllAbsencesQuery());
        }

        [HttpGet]
        [Route("approvable")]
        public async Task<List<Absence>> GetApprovable()
        {
            return await Mediator.Send(new GetApprovableAbsencesQuery());
        }

        [HttpPost]
        public async Task Create(CreateAbsenceCommand command)
        {
            await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<Absence> Update(UpdateAbsenceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteAbsenceCommand {Id = id});
        }
    }
}