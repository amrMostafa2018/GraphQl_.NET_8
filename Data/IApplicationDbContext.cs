
using GrapGraph_QL_Dot_NET_8.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrapGraph_QL_Dot_NET_8.Data {
    public interface IApplicationDbContext {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
