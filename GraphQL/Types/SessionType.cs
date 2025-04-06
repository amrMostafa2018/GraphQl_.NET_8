using GrapGraph_QL_Dot_NET_8.Entities;

namespace Graph_QL_Dot_NET_8.GraphQL.Types
{
    public class SessionType : ObjectType<Session>
    {
        protected override void Configure(IObjectTypeDescriptor<Session> descriptor)
        {
            descriptor.Field(b => b.Id)
                .Description("The unique identifier for the Session.");

            descriptor.Field(b => b.Title)
                .Description("The title of the Session.")
                .Type<StringType>();

            descriptor.Field(b => b.Type)
                .Description("The availability status of the Session.")
                .Type<NonNullType<EnumType<SessionAttendType>>>();

        }
    }
}
