# Étape 1 : Utiliser l'image SDK .NET 8.0 pour la compilation
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY src/Tenisu.Api/*.csproj ./src/Tenisu.Api/
COPY src/Tenisu.Application/*.csproj ./src/Tenisu.Application/
COPY src/Tenisu.Contracts/*.csproj ./src/Tenisu.Contracts/
COPY src/Tenisu.Domain/*.csproj ./src/Tenisu.Domain/
COPY src/Tenisu.Infrastructure/*.csproj ./src/Tenisu.Infrastructure/
COPY tests/UnitTests/Tenisu.Domain.UnitTests/*.csproj ./tests/UnitTests/Tenisu.Domain.UnitTests/
COPY tests/UnitTests/Tenisu.Infrastructure.UnitTests/*.csproj ./tests/UnitTests/Tenisu.Infrastructure.UnitTests/

RUN dotnet restore

COPY . .

WORKDIR /src/src/Tenisu.Api
RUN dotnet publish -c Release -o /app/publish

ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

COPY src/Tenisu.Infrastructure/Persistence/headtohead.json /app/Persistence/headtohead.json

EXPOSE 80

ENTRYPOINT ["dotnet", "Tenisu.Api.dll"]