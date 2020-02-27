# Messaging App

A simple instant messaging application created using C#, and .NET Core

## Setup

Building MessagingApp from source requires the following programs:
* .NET Core CLI
* Docker
* dotnet-ef

Clone this repo to your desired location and move into that directory.

Use the .NET Core CLI to build MessagingApp.

```bash
dotnet build
```

Install the Microsoft SQL Server on Linux image.

```bash
docker pull mcr.microsoft.com/mssql/server:2017-latest
```

Create a container using that image.

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Your_password123" \
    -p 1433:1433 --name MessagingApp1 \
    -d mcr.microsoft.com/mssql/server:2017-latest
```

Then, you have to apply the necessary migrations to the database using the 
provided shell script.

```bash
./update_database.sh
```

## Usage

The MessagingApp application can be ran using the provided run script.

```bash
./run.sh
```

