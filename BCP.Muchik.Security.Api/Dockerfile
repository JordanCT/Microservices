#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BCP.Muchik.Security.Api/BCP.Muchik.Security.Api.csproj", "BCP.Muchik.Security.Api/"]
COPY ["BCP.Muchik.Security.Application/BCP.Muchik.Security.Application.csproj", "BCP.Muchik.Security.Application/"]
COPY ["BCP.Muchik.Infrastructure.CrossCutting/BCP.Muchik.Infrastructure.CrossCutting.csproj", "BCP.Muchik.Infrastructure.CrossCutting/"]
COPY ["BCP.Muchik.Security.Domain/BCP.Muchik.Security.Domain.csproj", "BCP.Muchik.Security.Domain/"]
COPY ["BCP.Muchik.Security.Infrastructure/BCP.Muchik.Security.Infrastructure.csproj", "BCP.Muchik.Security.Infrastructure/"]
RUN dotnet restore "BCP.Muchik.Security.Api/BCP.Muchik.Security.Api.csproj"
COPY . .
WORKDIR "/src/BCP.Muchik.Security.Api"
RUN dotnet build "BCP.Muchik.Security.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BCP.Muchik.Security.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCP.Muchik.Security.Api.dll"]