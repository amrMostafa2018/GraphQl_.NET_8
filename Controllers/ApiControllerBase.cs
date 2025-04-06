using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrapGraph_QL_Dot_NET_8.Controllers {
    [ApiController]
    [Route("[controller]")]

    public abstract class ApiControllerBase : ControllerBase {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
