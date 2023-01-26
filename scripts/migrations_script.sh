export ASPNETCORE_ENVIRONMENT=Local
dotnet ef migrations script "$1" "$2" -p EntityFrameworkDemo.Data -s EntityFrameworkDemo.Web -o ./script.sql
