using GrapGraph_QL_Dot_NET_8.Data;
using GrapGraph_QL_Dot_NET_8.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrapGraph_QL_Dot_NET_8.REST.Sessions.Queries.GetSession
{
    public record GetSessionQuery(int Id) : IRequest<Session> { }
    public class GetSessionsQueryHandler : IRequestHandler<GetSessionQuery, Session>
    {
        private readonly IApplicationDbContext _context;
        public GetSessionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Session> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            var session = await _context
               .Sessions
               .Include(f => f.Attendees)
               .FirstOrDefaultAsync(f => f.Id == request.Id);
            if (session == null)
                throw new Exception($"Session with id {request.Id} was not found");
            return session;
        }

    }
}
