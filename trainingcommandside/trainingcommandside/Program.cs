using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using trainingcommandside.Abstraction;
using trainingcommandside.Infrastructure.MessageBus;
using trainingcommandside.Infrastructure.Persistance;
using trainingcommandside.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("Customers"), ServiceLifetime.Transient);
builder.Services.AddScoped<IEventStore, EventStore>();
//builder.Services.AddScoped<ICustomersQueriesService, UniqueCustomersService>();
builder.Services.AddSingleton(new ServiceBusClient(""));
builder.Services.AddSingleton<ServiceBusPublisher>();




var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<InvitationsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
