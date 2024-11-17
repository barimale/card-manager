# card-manager
## Prereqs
- MS Sql management studio
## step by step
```
Install migrations
Execute card manager microservice
Execute desktop app
```
## Tips
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet ef database update --connection "Data Source=gifter.db"
```
