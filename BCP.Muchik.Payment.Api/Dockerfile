#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BCP.Muchik.Payment.Api/BCP.Muchik.Payment.Api.csproj", "BCP.Muchik.Payment.Api/"]
COPY ["BCP.Muchik.Infrastructure.EventBusRabbitMQ/BCP.Muchik.Infrastructure.EventBusRabbitMQ.csproj", "BCP.Muchik.Infrastructure.EventBusRabbitMQ/"]
COPY ["BCP.Muchik.Infrastructure.EventBus/BCP.Muchik.Infrastructure.EventBus.csproj", "BCP.Muchik.Infrastructure.EventBus/"]
COPY ["BCP.Muchik.Payment.Application/BCP.Muchik.Payment.Application.csproj", "BCP.Muchik.Payment.Application/"]
COPY ["BCP.Muchik.Payment.Domain/BCP.Muchik.Payment.Domain.csproj", "BCP.Muchik.Payment.Domain/"]
COPY ["BCP.Muchik.Payment.Infrastructure/BCP.Muchik.Payment.Infrastructure.csproj", "BCP.Muchik.Payment.Infrastructure/"]
RUN dotnet restore "BCP.Muchik.Payment.Api/BCP.Muchik.Payment.Api.csproj"
COPY . .
WORKDIR "/src/BCP.Muchik.Payment.Api"
RUN dotnet build "BCP.Muchik.Payment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BCP.Muchik.Payment.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCP.Muchik.Payment.Api.dll"]