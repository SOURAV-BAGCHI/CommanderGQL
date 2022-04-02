using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<AppDbContext>(opt=> opt.UseSqlServer
        (builder.Configuration.GetConnectionString("CommandConStr")));

builder.Services.
    AddGraphQLServer().
    AddQueryType<Query>();



var app = builder.Build();

app.MapGraphQL();
app.UseGraphQLVoyager(new VoyagerOptions(){
    GraphQLEndPoint="/graphql"
},path:"/graphql-voyager");

app.Run();
