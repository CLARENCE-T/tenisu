# Étape 1 : Utiliser l'image SDK .NET 8.0 pour la compilation
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier le fichier solution et restaurer les dépendances
COPY *.sln ./
COPY src/Tenisu.Api/*.csproj ./src/Tenisu.Api/
COPY src/Tenisu.Application/*.csproj ./src/Tenisu.Application/
COPY src/Tenisu.Contracts/*.csproj ./src/Tenisu.Contracts/
COPY src/Tenisu.Domain/*.csproj ./src/Tenisu.Domain/
COPY src/Tenisu.Infrastructure/*.csproj ./src/Tenisu.Infrastructure/
COPY tests/UnitTests/Tenisu.Domain.UnitTests/*.csproj ./tests/UnitTests/Tenisu.Domain.UnitTests/
COPY tests/UnitTests/Tenisu.Infrastructure.UnitTests/*.csproj ./tests/UnitTests/Tenisu.Infrastructure.UnitTests/

# Restaurer les dépendances
RUN dotnet restore

# Copier tous les fichiers de chaque projet, y compris le fichier JSON
COPY . .

# Publier le projet API  (Tenisu.Api)
WORKDIR /src/src/Tenisu.Api
RUN dotnet publish -c Release -o /app/publish

# Étape 2 : Utiliser l'image runtime .NET 8.0 pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Copie du fichier JSON dans le dossier cible du conteneur
COPY src/Tenisu.Infrastructure/Persistence/headtohead.json /app/Persistence/headtohead.json

# Exposer le port utilisé par votre API (généralement 80)
EXPOSE 80

# Démarrer l'application
ENTRYPOINT ["dotnet", "Tenisu.Api.dll"]