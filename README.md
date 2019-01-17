# Carneiro Host

Lightweight library to handle background services for dotnet core host projects.

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

## Changelogs

### [1.0.1] - 2019-01-17

- First release

## Team

@rjcarneiro