using BCP.Muchik.Infrastructure.CrossCutting.Jwt;
using BCP.Muchik.Infrastructure.CrossCutting.Statics;
using BCP.Muchik.Security.Api.Middleware;
using BCP.Muchik.Security.Application.Interfaces;
using BCP.Muchik.Security.Application.Mappings;
using BCP.Muchik.Security.Application.Services;
using BCP.Muchik.Security.Domain.Interfaces;
using BCP.Muchik.Security.Infrastructure.Context;
using BCP.Muchik.Security.Infrastructure.Repositories;
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

//SQL Server
builder.Services.AddDbContext<SecurityContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:SecurityConnection"));
});
//Automapper
builder.Services.AddAutoMapper(typeof(DtoToEntityProfile));
//Services
builder.Services.AddTransient<ISecurityService, SecurityService>();
//Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
//Context
builder.Services.AddTransient<SecurityContext>();
//CrossCutting
builder.Services.AddTransient<IJwtManager, JwtManager>();

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment(CustomEnvironments.Development))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
