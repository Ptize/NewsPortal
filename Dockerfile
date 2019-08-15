FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY NewsPortal/*.csproj ./NewsPortal/
COPY NewsPortal.Domain/*.csproj ./NewsPortal.Domain/
COPY NewsPortal.Data/*.csproj ./NewsPortal.Data/
COPY NewsPortal.Models/*.csproj ./NewsPortal.Models/
RUN dotnet restore

# copy everything else and build app
COPY NewsPortal/* ./NewsPortal/
COPY NewsPortal.Domain/* ./NewsPortal.Domain/
COPY NewsPortal.Data/* ./NewsPortal.Data/
COPY NewsPortal.Models/* ./NewsPortal.Models/
# RUN Remove-Item ./NewsPortal*/obj/*/netcoreapp2.1/*AssemblyInfo*
RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
# WORKDIR /app
COPY --from=build /app/NewsPortal/out ./
ENTRYPOINT ["dotnet", "NewsPortal.dll"]