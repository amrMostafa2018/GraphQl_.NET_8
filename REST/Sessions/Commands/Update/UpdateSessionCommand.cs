﻿using GrapGraph_QL_Dot_NET_8.Data;
using GrapGraph_QL_Dot_NET_8.Entities;
using MediatR;

namespace GrapGraph_QL_Dot_NET_8.REST.Sessions.Commands.Update {

    public record UpdateSessionCommand(AddSessionInput NewSession, int OldId) : IRequest<Session> { }

    public class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand, Session> {
        private readonly IApplicationDbContext _context;

        public UpdateSessionCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Session> Handle(UpdateSessionCommand request, CancellationToken cancellationToken) {
            var Session = await _context.Sessions.FindAsync(request.OldId);
            if (Session == null)
                throw new Exception($"Session with id {request.OldId} was not found!");
            
            Session.Title = request.NewSession.Title;
            Session.Description = request.NewSession.Description;
            Session.StartTime = request.NewSession.StartTime;
            Session.EndTime = request.NewSession.EndTime;
            Session.Type = request.NewSession.Type;

            await _context.SaveChangesAsync(cancellationToken);
            return Session;
        }

    }
}
