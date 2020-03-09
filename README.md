# Messaging App
A simple instant messaging REST API created using C# and .NET Core.

## Table of Contents
* [Setup](#setup)
* [Usage](#usage)
* [Testing](#testing)

## Setup
Building MessagingApp from source requires the following programs:
* .NET Core Runtime 3.1.2
* .NET Core CLI
* Docker
* dotnet-ef

Clone this repo to your desired location and move into that directory.

Use the .NET Core CLI to build MessagingApp.

```shell
dotnet build
```

Install the Microsoft SQL Server on Linux image.

```shell
docker pull mcr.microsoft.com/mssql/server:2017-latest
```

Create a container using that image.

```shell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Your_password123" \
    -p 1433:1433 --name MessagingApp1 \
    -d mcr.microsoft.com/mssql/server:2017-latest
```

Then, you have to apply the necessary migrations to the database using the 
provided shell scripts.

On macOS/Linux:
```shell
./update_database.sh
```

On Windows:
```shell
update_database.bat
```

## Usage
The MessagingApp application can be ran using the provided run scripts.

On macOS/Linux:
```shell
./run.sh
```

On Windows:
```shell
run.bat
```

This will create a MessagingApp that listens on port 5001.

## Testing
To run all tests during development of MessagingApp run the following command:
```shell
dotnet test
```
