﻿using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.Data;
using MediatR;

namespace GrapGraph_QL_Dot_NET_8.REST.Tracks.Commands.Update
{
    public record UpdateTrackCommand(string NewName, int OldId) : IRequest<Track> { }
    public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand, Track>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTrackCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Track> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _context.Tracks.FindAsync(request.OldId);
            if (track == null)
                throw new Exception($"Track with id {request.OldId} was not found!");
            track.Name = request.NewName;
            await _context.SaveChangesAsync(cancellationToken);
            return track;
        }

    }
}
