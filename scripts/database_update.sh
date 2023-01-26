export ASPNETCORE_ENVIRONMENT=Local
dotnet ef database update "$1" -p EntityFrameworkDemo.Data -s EntityFrameworkDemo.Web
