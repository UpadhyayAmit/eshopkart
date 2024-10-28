using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMediatR(option => option.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database")!); 
}).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();
app.Run();
