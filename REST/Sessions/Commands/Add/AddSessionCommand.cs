using GrapGraph_QL_Dot_NET_8.Data;
using GrapGraph_QL_Dot_NET_8.Entities;
using MediatR;

namespace GrapGraph_QL_Dot_NET_8.REST.Sessions.Commands.Add
{

    public record AddSessionCommand(AddSessionInput Input) : IRequest<Session> { }

    public class AddSessionCommandHandler : IRequestHandler<AddSessionCommand, Session>
    {
        private readonly IApplicationDbContext _context;

        public AddSessionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Session> Handle(AddSessionCommand request, CancellationToken cancellationToken)
        {
            var track = await _context.Tracks.FindAsync(request.Input.TrackId);
            if (track == null)
                throw new Exception("Track not found");

            var session = new Session
            {
                Title = request.Input.Title,
                Description = request.Input.Description,
                StartTime = request.Input.StartTime,
                EndTime = request.Input.EndTime,
                Track = track,
                Type = request.Input.Type
            };
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync(cancellationToken);
            return session;
        }

    }
}
