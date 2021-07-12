using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplicationWithAngular.Controllers
{
    public abstract class BaseApiController : Controller
    {
        protected IMediator Mediator { get; }

        protected BaseApiController()
        {
        }

        protected BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}