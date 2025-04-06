using GrapGraph_QL_Dot_NET_8.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Graph_QL_Dot_NET_8.GraphQL.Queries;
using GrapGraph_QL_Dot_NET_8.GraphQL.Queries;
using Graph_QL_Dot_NET_8.GraphQL.Mutations;
using Graph_QL_Dot_NET_8.GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<TrackQuery>()
    .AddTypeExtension<SessionQuery>()
    .AddMutationType<Mutation>()
    .AddType<TrackType>() // register object type
    .AddType<SessionType>() // register object type
    .AddType<SearchResultType>()  // Register interface type
    .AddType<TestClassType>()  // Register interface type
    .AddTypeExtension<TrackMutation>()
    .AddFiltering()
    .AddSorting()
    .AddAuthorization(); // 👈 Required for GraphQL Auth;

//Add JWT
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidIssuers = new string[] { builder.Configuration["Jwt:Issuer"] },
        ValidAudiences = new string[] { builder.Configuration["Jwt:Issuer"] },
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true
    };
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", corsPolicyBuilder => corsPolicyBuilder
     .AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(hostName => true));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGraphQL();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
