using Graph_QL_Dot_NET_8.Entities;
using HotChocolate.Authorization;

namespace GrapGraph_QL_Dot_NET_8.GraphQL.Queries
{
    public class Query
    {
        public string Hello() => "Hello from GraphQL!";
        public IEnumerable<testClass> Search()
        {
            return new List<testClass>()
            {
                 new testClass {Id = 1 , Name = "GraphQL Basics"},
                 new testClass {Id = 2 , Name="Jane Doe"}
            };
        }
        [Authorize]  // 👈 Restricted Access
        public string PrivateInfo() => "Confidential: Only authenticated users can see this!";
    }
}
