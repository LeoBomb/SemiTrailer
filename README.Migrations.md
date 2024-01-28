# RUN

dotnet ef migrations add SeedData11 --startup-project ..\SemiTrailer\ --project ./Infrastructure.csproj --msbuildprojectextensionspath ./

dotnet ef migrations remove --startup-project ..\SemiTrailer\ --project ./Infrastructure.csproj --msbuildprojectextensionspath ./

dotnet ef database update --startup-project ..\SemiTrailer\ --project ./Infrastructure.csproj --msbuildprojectextensionspath ./


dotnet ef migrations add init --project ./TenantDb.csproj

dotnet ef database update