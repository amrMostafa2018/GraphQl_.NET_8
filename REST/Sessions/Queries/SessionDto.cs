using GrapGraph_QL_Dot_NET_8.Entities;

namespace GrapGraph_QL_Dot_NET_8.REST.Sessions.Queries {
    public class SessionDto {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        public int? TrackId { get; set; }

        public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();

        public TimeSpan Duration => EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ?? TimeSpan.Zero;
    }
}
