using Graph_QL_Dot_NET_8.Interface;

namespace Graph_QL_Dot_NET_8.GraphQL.Types
{
    public class SearchResultType : InterfaceType<ISearchResult>
    {
        protected override void Configure(IInterfaceTypeDescriptor<ISearchResult> descriptor)
        {
            descriptor.Description("A search result.");

            descriptor.Field(f => f.Id)
                      .Description("The unique identifier of the result.");

        }
    }
}
