# Base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Copy and restore dependencies
COPY ["API/API.csproj", "API/"]
RUN dotnet restore "./API/API.csproj"

# Copy the rest of the app source
COPY . .
WORKDIR "/src/API"

# Build the app
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

# FINAL IMAGE: Uses ASP.NET runtime instead of just runtime dependencies
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

# Copy the published app
COPY --from=publish /app/publish .

# Correct entrypoint
ENTRYPOINT ["dotnet", "API.dll"]
