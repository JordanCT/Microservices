#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BCP.Muchik.Infrastructure.Gateway.Api/BCP.Muchik.Infrastructure.Gateway.Api.csproj", "BCP.Muchik.Infrastructure.Gateway.Api/"]
COPY ["BCP.Muchik.Infrastructure.CrossCutting/BCP.Muchik.Infrastructure.CrossCutting.csproj", "BCP.Muchik.Infrastructure.CrossCutting/"]
RUN dotnet restore "BCP.Muchik.Infrastructure.Gateway.Api/BCP.Muchik.Infrastructure.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/BCP.Muchik.Infrastructure.Gateway.Api"
RUN dotnet build "BCP.Muchik.Infrastructure.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BCP.Muchik.Infrastructure.Gateway.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCP.Muchik.Infrastructure.Gateway.Api.dll"]