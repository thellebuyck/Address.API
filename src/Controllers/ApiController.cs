using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Address.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class ApiController:ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
