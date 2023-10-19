using BCP.Muchik.Infrastructure.CrossCutting.Statics;
using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Infrastructure.EventBusRabbitMQ;
using BCP.Muchik.Infrastructure.EventBusRabbitMQ.Settings;
using BCP.Muchik.Invoicement.Application.EventHandlers;
using BCP.Muchik.Invoicement.Application.Events;
using BCP.Muchik.Invoicement.Application.Interfaces;
using BCP.Muchik.Invoicement.Application.Mappings;
using BCP.Muchik.Invoicement.Application.Services;
using BCP.Muchik.Invoicement.Domain.Interfaces;
using BCP.Muchik.Invoicement.Infrastructure.Context;
using BCP.Muchik.Invoicement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

// Add config server
builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Postgres
builder.Services.AddDbContext<InvoicementContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionStrings:InvoicementConnection"));
});
//RabbitMQ
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.RegisterRabbitServices(builder.Configuration);

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));
//Services
builder.Services.AddTransient<IInvoicementService, InvoicementService>();
//Repositories
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
//Context
builder.Services.AddTransient<InvoicementContext>();
//Event & EventHandlers
builder.Services.AddTransient<IEventHandler<InvoicePayEvent>, InvoicePayEventHandler>();
builder.Services.AddTransient<InvoicePayEventHandler>();

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

//Subscriptions EventBus
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<InvoicePayEvent, InvoicePayEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment(CustomEnvironments.Development))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
