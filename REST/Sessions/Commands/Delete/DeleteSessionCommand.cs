using GrapGraph_QL_Dot_NET_8.Data;
using GrapGraph_QL_Dot_NET_8.Entities;
using MediatR;

namespace GrapGraph_QL_Dot_NET_8.REST.Sessions.Commands.Delete
{
    public record DeleteSessionCommand(int Id) : IRequest<Session> { }
    public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, Session>
    {
        private readonly IApplicationDbContext _context;
        public DeleteSessionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Session> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            var Session = await _context.Sessions.FindAsync(request.Id);
            if (Session == null)
                throw new Exception($"Session with id {request.Id} was not found!");

            _context.Sessions.Remove(Session);
            await _context.SaveChangesAsync(cancellationToken);
            return Session;
        }

    }
}
