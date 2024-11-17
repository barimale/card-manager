# card-manager
## Prereqs
- MS SQL Instance
## Step by step
### Apply migrations
Ensure connection string is properly set in appsettings.json, then
navigate to microservice/Card.Infrastructure folder and execute:
```
dotnet ef database update
```
### Multiple solutions
Open two solutions located in microservice and ui folders.
Press Start Debugging.
### Desktop app
Start using desktop app by navigating via tabs and inserting data.
