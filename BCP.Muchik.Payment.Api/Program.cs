using BCP.Muchik.Infrastructure.EventBusRabbitMQ;
using BCP.Muchik.Infrastructure.EventBusRabbitMQ.Settings;
using BCP.Muchik.Payment.Application.Interfaces;
using BCP.Muchik.Payment.Application.Mappings;
using BCP.Muchik.Payment.Application.Services;
using BCP.Muchik.Payment.Domain.Interfaces;
using BCP.Muchik.Payment.Infrastructure.Context;
using BCP.Muchik.Payment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MySql
builder.Services.AddDbContext<PaymentContext>(config =>
{
    config.UseMySQL(builder.Configuration.GetConnectionString("PaymentConnection"));
    //config.UseMySQL(builder.Configuration.GetValue<string>("ConnectionStrings:PaymentConnection"));
});
//RabbitMQ
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.RegisterRabbitServices(builder.Configuration);
//AutoMapper
builder.Services.AddAutoMapper(typeof(DtoToEntityProfile));
//Services
builder.Services.AddTransient<IPaymentService, PaymentService>();
//Repositories
builder.Services.AddTransient<IPayRepository, PayRepository>();
//Context
builder.Services.AddTransient<PaymentContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();