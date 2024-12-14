# card-manager
## Prereqs
- Docker Desktop
- .NET 8.0 SDK

## SQL server:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password_123#" -p 1500:1433 --name sql_server_container mcr.microsoft.com/mssql/server

```
## Step by step
### Run solutions
Open two solutions located in microservice and ui folders.
Press Start Debugging.
### Use desktop app
Start using desktop app by navigating via tabs and inserting data.
