using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Infrastructure.EventBusRabbitMQ;
using BCP.Muchik.Infrastructure.EventBusRabbitMQ.Settings;
using BCP.Muchik.Movement.Application.EventHandlers;
using BCP.Muchik.Movement.Application.Events;
using BCP.Muchik.Movement.Application.Interfaces;
using BCP.Muchik.Movement.Application.Mappings;
using BCP.Muchik.Movement.Application.Services;
using BCP.Muchik.Movement.Domain.Interfaces;
using BCP.Muchik.Movement.Infrastructure.Context;
using BCP.Muchik.Movement.Infrastructure.Repositories;
using BCP.Muchik.Movement.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MongoDb
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MovementDatabase"));
//RabbitMQ
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.RegisterRabbitServices(builder.Configuration);
//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));
//Services
builder.Services.AddTransient<IMovementService, MovementService>();
//Repositories
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
//Context
builder.Services.AddSingleton<MovementContext>();
//Event & EventHandlers
builder.Services.AddTransient<IEventHandler<TransactionConfirmEvent>, TransactionConfirmEventHandler>();
builder.Services.AddTransient<TransactionConfirmEventHandler>();

var app = builder.Build();

//Subscriptions EventBus
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<TransactionConfirmEvent, TransactionConfirmEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
