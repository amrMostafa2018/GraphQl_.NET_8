using GrapGraph_QL_Dot_NET_8.Controllers;
using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.REST.Tracks.Commands.Add;
using GrapGraph_QL_Dot_NET_8.REST.Tracks.Queries.GetTracks;
using Microsoft.AspNetCore.Mvc;

namespace Graph_QL_Dot_NET_8.Controllers
{
    public class TracksController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddTrackCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<List<Track>> GetTracks() => await Mediator.Send(new GetTracksQuery());

    }
}
