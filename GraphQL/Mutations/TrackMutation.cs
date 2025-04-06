using ConferencePlanner.REST.Tracks.Commands.Delete;
using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.REST.Tracks.Commands.Add;
using GrapGraph_QL_Dot_NET_8.REST.Tracks.Commands.Update;
using Graph_QL_Dot_NET_8.GraphQL.Models.AddTrack;
using MediatR;

namespace Graph_QL_Dot_NET_8.GraphQL.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class TrackMutation
    {
        public async Task<Track> createTrack(TrackInput input, [Service] IMediator mediatr)
        {
            return await mediatr.Send(new AddTrackCommand(input.Name));
        }

        public async Task<Track> updateTrack(TrackInput input, int trackId, [Service] IMediator mediatr)
        {
            return await mediatr.Send(new UpdateTrackCommand(input.Name, trackId));
        }

        public async Task<bool> deleteTrack(int trackId, [Service] IMediator mediatr)
        {
            return await mediatr.Send(new DeleteTrackCommand(trackId));
        }
    }
}
