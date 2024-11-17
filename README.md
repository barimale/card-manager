# card-manager
## Prereqs
- MS SQL Instance
- .NET 8.0
## Step by step
### Apply migrations
Ensure connection string is properly set in appsettings.json, then
navigate to microservice/Card.Infrastructure folder and execute:
```
dotnet ef database update
```
### Run solutions
Open two solutions located in microservice and ui folders.
Press Start Debugging.
### Use desktop app
Start using desktop app by navigating via tabs and inserting data.
