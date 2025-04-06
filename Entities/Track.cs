using System.ComponentModel.DataAnnotations;

namespace GrapGraph_QL_Dot_NET_8.Entities {
    public class Track {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Session>? Sessions { get; set; } = new List<Session>();
    }
}
