using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.GraphQL.Queries;
using GrapGraph_QL_Dot_NET_8.REST.Tracks.Queries.GetTracks;
using MediatR;

namespace Graph_QL_Dot_NET_8.GraphQL.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class TrackQuery
    {
        public async Task<List<Track>> tracks([Service] IMediator mediatr)
        {
            return await mediatr.Send(new GetTracksQuery());
        }
    }
}
