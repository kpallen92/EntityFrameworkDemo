export ASPNETCORE_ENVIRONMENT=Local
dotnet ef migrations add "$1" -p EntityFrameworkDemo.Data -s EntityFrameworkDemo.Web


