#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BCP.Muchik.Movement.Api/BCP.Muchik.Movement.Api.csproj", "BCP.Muchik.Movement.Api/"]
COPY ["BCP.Muchik.Infrastructure.EventBusRabbitMQ/BCP.Muchik.Infrastructure.EventBusRabbitMQ.csproj", "BCP.Muchik.Infrastructure.EventBusRabbitMQ/"]
COPY ["BCP.Muchik.Infrastructure.EventBus/BCP.Muchik.Infrastructure.EventBus.csproj", "BCP.Muchik.Infrastructure.EventBus/"]
COPY ["BCP.Muchik.Movement.Application/BCP.Muchik.Movement.Application.csproj", "BCP.Muchik.Movement.Application/"]
COPY ["BCP.Muchik.Movement.Domain/BCP.Muchik.Movement.Domain.csproj", "BCP.Muchik.Movement.Domain/"]
COPY ["BCP.Muchik.Movement.Infrastructure/BCP.Muchik.Movement.Infrastructure.csproj", "BCP.Muchik.Movement.Infrastructure/"]
RUN dotnet restore "BCP.Muchik.Movement.Api/BCP.Muchik.Movement.Api.csproj"
COPY . .
WORKDIR "/src/BCP.Muchik.Movement.Api"
RUN dotnet build "BCP.Muchik.Movement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BCP.Muchik.Movement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCP.Muchik.Movement.Api.dll"]