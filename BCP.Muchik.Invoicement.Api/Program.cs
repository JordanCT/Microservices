using BCP.Muchik.Invoicement.Application.Interfaces;
using BCP.Muchik.Invoicement.Application.Mappings;
using BCP.Muchik.Invoicement.Application.Services;
using BCP.Muchik.Invoicement.Domain.Interfaces;
using BCP.Muchik.Invoicement.Infrastructure.Context;
using BCP.Muchik.Invoicement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Postgres
builder.Services.AddDbContext<InvoicementContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetConnectionString("InvoicementConnection"));
});
//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));
//Services
builder.Services.AddTransient<IInvoicementService, InvoicementService>();
//Repositories
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
//Context
builder.Services.AddTransient<InvoicementContext>();

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
