#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BCP.Muchik.Invoicement.Api/BCP.Muchik.Invoicement.Api.csproj", "BCP.Muchik.Invoicement.Api/"]
COPY ["BCP.Muchik.Infrastructure.CrossCutting/BCP.Muchik.Infrastructure.CrossCutting.csproj", "BCP.Muchik.Infrastructure.CrossCutting/"]
COPY ["BCP.Muchik.Infrastructure.EventBusRabbitMQ/BCP.Muchik.Infrastructure.EventBusRabbitMQ.csproj", "BCP.Muchik.Infrastructure.EventBusRabbitMQ/"]
COPY ["BCP.Muchik.Infrastructure.EventBus/BCP.Muchik.Infrastructure.EventBus.csproj", "BCP.Muchik.Infrastructure.EventBus/"]
COPY ["BCP.Muchik.Invoicement.Application/BCP.Muchik.Invoicement.Application.csproj", "BCP.Muchik.Invoicement.Application/"]
COPY ["BCP.Muchik.Invoicement.Domain/BCP.Muchik.Invoicement.Domain.csproj", "BCP.Muchik.Invoicement.Domain/"]
COPY ["BCP.Muchik.Invoicement.Infrastructure/BCP.Muchik.Invoicement.Infrastructure.csproj", "BCP.Muchik.Invoicement.Infrastructure/"]
RUN dotnet restore "BCP.Muchik.Invoicement.Api/BCP.Muchik.Invoicement.Api.csproj"
COPY . .
WORKDIR "/src/BCP.Muchik.Invoicement.Api"
RUN dotnet build "BCP.Muchik.Invoicement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BCP.Muchik.Invoicement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCP.Muchik.Invoicement.Api.dll"]