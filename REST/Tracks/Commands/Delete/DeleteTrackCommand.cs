using GrapGraph_QL_Dot_NET_8.Data;
using MediatR;

namespace ConferencePlanner.REST.Tracks.Commands.Delete
{
    public record DeleteTrackCommand(int Id) : IRequest<bool> { }
    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTrackCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _context.Tracks.FindAsync(request.Id);
            if (track == null)
                throw new Exception($"Track with id {request.Id} was not found!");

            _context.Tracks.Remove(track);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}
