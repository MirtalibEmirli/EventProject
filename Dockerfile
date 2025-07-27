# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
 
# SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# COPY csproj files and restore
COPY Core/EventProject.Domain/EventProject.Domain.csproj Core/EventProject.Domain/
COPY Infrastructure/EventProject.Infrastructure/EventProject.Infrastructure.csproj Infrastructure/EventProject.Infrastructure/
COPY Infrastructure/EventProject.Persistence/EventProject.Persistence.csproj Infrastructure/EventProject.Persistence/
COPY Presentation/EventProject.Api/EventProject.Api.csproj Presentation/EventProject.Api/

# Restore
RUN dotnet restore Presentation/EventProject.Api/EventProject.Api.csproj

# COPY the rest of the source code
COPY . .

# Build
WORKDIR /src/Presentation/EventProject.Api
RUN dotnet build EventProject.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish EventProject.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventProject.Api.dll"]
