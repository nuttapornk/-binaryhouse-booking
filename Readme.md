# Booking

```
dotnet ef migrations add "InitialDatabase" --project .\src\Infrastructure\ --startup-project .\src\Booking\ --output-dir Persistence\Migrations
```

```
dotnet ef migrations remove --project .\src\Infrastructure\ --startup-project .\src\Booking\
```