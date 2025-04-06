using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrapGraph_QL_Dot_NET_8.REST.Tracks.Queries.GetTracks
{
    public class GetTracksQuery : IRequest<List<Track>> { }
    public class QueryQueryHandler : IRequestHandler<GetTracksQuery, List<Track>>
    {
        private readonly IApplicationDbContext _context;
        public QueryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Track>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tracks
                .Include(f => f.Sessions)
                .ToListAsync(cancellationToken);
        }

    }
}
