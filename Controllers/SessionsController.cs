using Microsoft.AspNetCore.Mvc;
using GrapGraph_QL_Dot_NET_8.Controllers;
using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.REST.Sessions.Commands.Add;
using GrapGraph_QL_Dot_NET_8.REST.Sessions.Queries.GetSession;
using Graph_QL_Dot_NET_8.REST;
using Microsoft.AspNetCore.Authorization;

namespace Graph_QL_Dot_NET_8.Controllers
{
   
    public class SessionsController : ApiControllerBase
    {
        private readonly IConfiguration _config;
        public SessionsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddSessionCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Session> GetSession(int id) => await Mediator.Send(new GetSessionQuery(id));
       
        [HttpGet("Generate Token")]
        public async Task<string> GenerateToken()
        {
            TokenService tokenService = new TokenService(_config);
            return tokenService.GenerateJwtToken("Amr", "Admin");
        }


    }
}
