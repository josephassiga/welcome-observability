# Observabilité : Mise en place de métriques personnalisées dans une application csharp.

## Contexte 

Ce projet à pour but de montrer la mise place des métriques personnalisées dans une application .NET.

## Péréquis :

```
 - .NET Core version : 6.0
 - Package Prometheus-net : 7.0
```

> **_NOTE:_** Si vous voulez avoir plus d'information sur le Package ***prometheus-net*** : https://github.com/prometheus-net/prometheus-net .

## Execution de l'application

Vous pouvez exécuter votre application en mode de développement qui permet le codage en direct en utilisant :
```shell script
$> dotnet watch

🔥 Hot reload enabled. For a list of supported edits, see https://aka.ms/dotnet/hot-reload.
  💡 Press "Ctrl + R" to restart.
dotnet watch 🔧 Building...
  Determining projects to restore...
  All projects are up-to-date for restore.
  observabilityapp -> /Users/josephassiga/Desktop/projects/EI/observabilityapp/bin/Debug/net6.0/observabilityapp.dll
The application is trying to access the ASP.NET Core developer certificate key. A prompt might appear to ask for permission to access the key. When that happens, select 'Always Allow' to grant 'dotnet' access to the certificate key in the future.
dotnet watch 🚀 Started
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

## Tester l'application :

### 1. Page d'acceuil :
```
$> curl localhost:8080
```

### 2. API welcome :
```
$> curl localhost:8080/welcome

Welcome For Custom Metrics Demo
```


### 3. Page swagger UI:
```
$> curl http://localhost:8080/swagger/index.html
```





