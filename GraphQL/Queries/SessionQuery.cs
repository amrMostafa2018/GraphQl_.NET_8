using GrapGraph_QL_Dot_NET_8.Entities;
using GrapGraph_QL_Dot_NET_8.GraphQL.Queries;
using GrapGraph_QL_Dot_NET_8.REST.Sessions.Queries.GetSession;
using MediatR;

namespace Graph_QL_Dot_NET_8.GraphQL.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class SessionQuery
    {
        public async Task<Session> session(int id, [Service] IMediator mediatr)
        {
            return await mediatr.Send(new GetSessionQuery(id));
        }
    }
}
