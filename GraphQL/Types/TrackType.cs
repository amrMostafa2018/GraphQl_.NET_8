using GrapGraph_QL_Dot_NET_8.Entities;
using HotChocolate.Types;

namespace Graph_QL_Dot_NET_8.GraphQL.Types
{
    public class TrackType : ObjectType<Track>
    {
        protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
        {
            descriptor.Description("An Track with Sessions.");

            descriptor.Field(a => a.Id)
                .Description("The unique identifier for the Track.");

             //Hide internal/private fields
            descriptor.Ignore(b => b.Name);

            //descriptor.Field(a => a.Name)
            //    .Description("The Track's name.")
            //    .Type<NonNullType<StringType>>();

            descriptor.Field(a => a.Sessions)
                .Description("The list of books written by this author.")
                .Type<NonNullType<ListType<ObjectType<Session>>>>();

        }
    }
}
