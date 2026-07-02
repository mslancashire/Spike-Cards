FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source
COPY ["build/AppSetup/AppSetup.csproj", "build/AppSetup/"]
# COPY ["src/Cards.Data/Cards.Data.csproj", "src/Cards.Data/"]
# COPY ["src/Cards.Model/Cards.Model.csproj", "src/Cards.Model/"]
RUN dotnet restore "./build/AppSetup/AppSetup.csproj"
COPY . .
RUN dotnet publish "./build/AppSetup/AppSetup.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet","AppSetup.dll"]