# card-manager
https://medium.com/@analyticscodeexplained/running-microsoft-sql-server-in-docker-a8dfdd246e45

## Prereqs
- MS SQL Instance
- .NET 8.0 SDK
## Step by step
### Apply migrations
Ensure connection string is properly set in appsettings.json and appsettings.Development.json, then
navigate to microservice/Card.Infrastructure folder and execute:
```
dotnet ef database update
```
### Run solutions
Open two solutions located in microservice and ui folders.
Press Start Debugging.
### Use desktop app
Start using desktop app by navigating via tabs and inserting data.
