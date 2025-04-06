using GrapGraph_QL_Dot_NET_8.Data;
using GrapGraph_QL_Dot_NET_8.Entities;
using MediatR;

namespace GrapGraph_QL_Dot_NET_8.REST.Attendees.Commands
{
    public record RegisterAttendeeCommand(int SessionId, Attendee Attendee) : IRequest<Attendee> { }
    public class RegisterAttendeeCommandHandler : IRequestHandler<RegisterAttendeeCommand, Attendee>
    {
        private readonly IApplicationDbContext _context;
        public RegisterAttendeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Attendee> Handle(RegisterAttendeeCommand request, CancellationToken cancellationToken)
        {
            var Session = await _context.Sessions.FindAsync(request.SessionId);
            if (Session == null)
                throw new Exception($"Session with id {request.SessionId} was not found!");

            var attendee = new Attendee { Name = request.Attendee.Name, Email = request.Attendee.Email };
            Session.Attendees.Add(attendee);
            await _context.SaveChangesAsync(cancellationToken);
            return attendee;
        }

    }
}
