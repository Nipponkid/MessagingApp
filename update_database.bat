@echo off
PUSHD src\MessagingApp
dotnet ef database update
POPD
