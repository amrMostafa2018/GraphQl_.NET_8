using Graph_QL_Dot_NET_8.Entities;

namespace Graph_QL_Dot_NET_8.GraphQL.Types
{
    public class TestClassType : ObjectType<testClass>
    {
        protected override void Configure(IObjectTypeDescriptor<testClass> descriptor)
        {
            descriptor.Implements<SearchResultType>();  // 👈 Link to interface
            descriptor.Field(b => b.Name);
        }
    }
}
