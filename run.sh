#!/bin/bash

# Start docker container
if ! docker start MessagingApp1; then 
    # Container doesn't exist so create it
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Your_password123" \
        -p 1433:1433 --name MessagingApp1 \
        -d mcr.microsoft.com/mssql/server:2017-latest
fi

# Run the MessagingApp server
cd src/MessagingApp
dotnet run

