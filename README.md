# Carneiro Host

![GitHub](https://img.shields.io/github/license/rjcarneiro/Carneiro.Host?style=flat-square) ![Nuget](https://img.shields.io/nuget/v/Carneiro.Host?style=flat-square) ![Nuget](https://img.shields.io/nuget/dt/Carneiro.Host?style=flat-square)

Lightweight library to handle background services for dotnet core host projects.

## Nuget Package

You can download this package directly from [Nuget.org](https://www.nuget.org/packages/Carneiro.Host).

## How to use

```csharp
var options = Options.Create<GenericHandlerSettings>(new GenericHandlerSettings
{
    Timeout = new GenericHandlerTimeoutSettings
    { 
        Min = 5,
        Max = 30
    }
});
```

### Settings on your config

On your appsettings.json, set your config:

```javascript
"GenericBackgroundService": {
    "Timeout" : {
        "Min": 10,
        "Max": 30
    }
}
```

## Changelogs

### [3.0.0] - 2019-09-28

- Migrate to dotnet core `3.0.0`;

### [1.0.1] - 2019-01-17

- First release;

## Team

[Ricardo Carneiro](https://github.com/rjcarneiro)