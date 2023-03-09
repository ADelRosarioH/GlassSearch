# GlassSearch
Implementation of Legacy code integration with a .NET 6 Minimal RESTful WebAPI 

### Information:
- Name: Anthony Del Rosario
- Email: adelrosarioh@gmail.com

### Runtime and SDKs
Download and install Docker (https://docs.docker.com/get-docker/)
Download and install .NET 6 SDK (https://dotnet.microsoft.com/download)

### Dependencies
Start MSSQL Server docker container if you don't a have local Microsoft SQL Server instance:

Go to your terminal and run:
```sh
docker run -d --hostname mssqldb --name mssqldb_dev -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123*" -p 14331:1433 mcr.microsoft.com/mssql/server
```

### How to Use
- Open this repository folder in the terminal
- Install project dependencies by running this command:
```sh
dotnet restore
```
  
- Start the application by running this command:
```sh
dotnet run
```

Wait a couple of seconds for the application to start-up and go to https://localhost:7097/swagger/index.html or run the following command in your terminal:
```sh
curl -X 'GET' \
  'https://localhost:7097/documents?query=Doloribus&matchAll=false' \
  -H 'accept: text/plain'
```

### Management Tools
To connect to MSSQL Server using SQL Management Studio or other tool use the following connection parameters:
- **Server**: localhost,1433
- **User**: SA
- **Password**: Password123*

### Technologies used

- .NET 6
- ASP.NET Core 6 Minimal API
- MSSQL Server 2019

### Libraries

- Entity Framework Core
- xUnit
- AutoFixture

### Requirements
Requirements can be found in this (pdf)[/Glass Test - Full-Stack Software Developer.pdf].
