# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cards.API.Minimal/Cards.API.Minimal.csproj", "Cards.API.Minimal/"]
COPY ["Cards.API.Common/Cards.API.Common.csproj", "Cards.API.Common/"]
COPY ["Cards.Data/Cards.Data.csproj", "Cards.Data/"]
COPY ["Cards.Model/Cards.Model.csproj", "Cards.Model/"]
RUN dotnet restore "./Cards.API.Minimal/Cards.API.Minimal.csproj"
COPY . .
WORKDIR "/src/Cards.API.Minimal"
RUN dotnet build "./Cards.API.Minimal.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cards.API.Minimal.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cards.API.Minimal.dll"]