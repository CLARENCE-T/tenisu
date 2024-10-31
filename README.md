# tenisu
API-Tennis-Players 


# Tenisu  API

Ce projet est une API pour la gestion des joueurs de tennis. Il utilise .NET avec une clean architecture et une base de données SQLite.

## Structure du Projet

Le projet est structuré en deux couches principales :

- **src/Api** : Contient le point d'entrée principal de l'application et les contrôleurs API.
- **src/Infrastructure** : Gère l'accès aux données, incluant le `DbContext`, les modèles de données et les migrations.
- **src/Domain** : Contient les entités de base du domaine et les règles d'entreprise.
- **src/Application** : Gère la logique métier, les interfaces de services et les cas d'utilisation.
- **tests/Tests** : Les tests unitaires et d'intégration sont situés dans le dossier `test` pour chaque couche.


## Prérequis

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) ou une version plus récente.
- [SQLite](https://www.sqlite.org/download.html) (inclus dans .NET pour les tests locaux).
- [Entity Framework Core CLI](https://docs.microsoft.com/ef/core/cli/dotnet) (pour les migrations).

## Installation

1. Clonez le dépôt :

   ```bash
    git clone https://github.com/CLARENCE-T/tenisu.git
    cd tenisu
    dotnet restore
    dotnet ef migrations add InitialMigration --project src/Tenisu.Infrastructure --startup-project src/Tenisu.Api
    dotnet run

Une fois l'application démarrée, ouvrez un navigateur et allez à l'adresse suivante :


http://localhost:5032/swagger/index.html


L'application est aussi en ligne sur Render et dockerisé.
https://tenisu-1xzw.onrender.com/swagger/index.html
