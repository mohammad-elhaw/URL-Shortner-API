# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["URLShortner Gateway/URLShortner Gateway.csproj", "URLShortner Gateway/"]
COPY ["Modules/Redirection/Redirection.API/Redirection.API.csproj", "Modules/Redirection/Redirection.API/"]
COPY ["Modules/Redirection/Redirection.Application/Redirection.Application.csproj", "Modules/Redirection/Redirection.Application/"]
COPY ["SharedKernel/Shared.Application/Shared.Application.csproj", "SharedKernel/Shared.Application/"]
COPY ["SharedKernel/Shared.Domain/Shared.Domain.csproj", "SharedKernel/Shared.Domain/"]
COPY ["Modules/URL Shortener/URLShortener.API/URLShortener.API.csproj", "Modules/URL Shortener/URLShortener.API/"]
COPY ["Modules/URL Shortener/URLShortener.Application/URLShortener.Application.csproj", "Modules/URL Shortener/URLShortener.Application/"]
COPY ["Modules/URL Shortener/URLShortener.Domain/URLShortener.Domain.csproj", "Modules/URL Shortener/URLShortener.Domain/"]
COPY ["Modules/URL Shortener/URLShortener.Infrastructure/URLShortener.Infrastructure.csproj", "Modules/URL Shortener/URLShortener.Infrastructure/"]
COPY ["SharedKernel/Shared.Infrastructure/Shared.Infrastructure.csproj", "SharedKernel/Shared.Infrastructure/"]
RUN dotnet restore "./URLShortner Gateway/URLShortner Gateway.csproj"
COPY . .
WORKDIR "/src/URLShortner Gateway"
RUN dotnet build "./URLShortner Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./URLShortner Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "URLShortner Gateway.dll"]